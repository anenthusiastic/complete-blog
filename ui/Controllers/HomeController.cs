using data.Abstract;
using entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ui.ViewModels;

namespace firstapp.Controllers
{
    public class HomeController:Controller
    {
        private static string admindisplay = "none";
        private static string userdisplay = "";
        private static bool admin = false;
        private IPostRepository _postrepository;
        private IHeaderRepository _headerrepository;
        private IPostCategoryRepository _postcategoryrepository;
        private ICategoryRepository _categoryrepository;
        private IMessageRepository _messagerepository;
        private ICommentRepository _commentRepository ;
        private ILoginInfoRepository _logininforepository ;
        public HomeController(IPostRepository _postrepository,
            IHeaderRepository _headerrepository, 
            IPostCategoryRepository _postcategoryrepository,
            ICategoryRepository _categoryrepository,
            IMessageRepository _messagerepository,
            ICommentRepository _commentRepository,
            ILoginInfoRepository _logininforepository){

            this._postrepository = _postrepository;
            this._categoryrepository = _categoryrepository;
            this._headerrepository = _headerrepository;
            this._messagerepository = _messagerepository;
            this._postcategoryrepository = _postcategoryrepository;
            this._commentRepository = _commentRepository;
            this._logininforepository = _logininforepository;
        }

        public IActionResult Index(string pagenumber){
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            ViewBag.header = _headerrepository.GetById(4);
            ViewBag.categories = _categoryrepository.GetAll();
            List<Post> allPosts = _postrepository.GetAll().OrderByDescending(p => p.date).ToList();
            int postcount = allPosts.Count;
            List<Post> posts ;
            if(string.IsNullOrEmpty(pagenumber) ){
                posts = allPosts.GetRange(0,5);
                ViewBag.page = "2";
            }
            else{
                int pn = Convert.ToInt32(pagenumber);
                ViewBag.page = Convert.ToString(pn+1);
                if((int)postcount/5 > pn){
                    posts = allPosts.GetRange((int)pn*5-5,(int)pn*5);
                }
                else if(pn==(int)postcount/5){
                    posts = allPosts.GetRange(postcount-5,postcount);
                }
                else if(pn-1 == (int)postcount/5){
                    posts = allPosts.GetRange((int)pn*5-5,postcount);
                    ViewBag.olderPostsButton = "disabled";
                }
                else {
                    return View("error");
                }
            }
            
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            foreach (var item in posts)
            {
                List<string> categorynames = new List<string>();
                var ids = _postcategoryrepository.GetCategories(item.id);
                foreach (var id in ids)
                {
                    categorynames.Add(_categoryrepository.GetById(id).name);
                }
                PostViewModel postviewmodel = new PostViewModel(){
                    post = item,
                    categoryNames = categorynames,
                    postHeader = _headerrepository.GetById(item.headerId)
                };
                postViewModels.Add(postviewmodel);
            }
            popularposts();
            return View(postViewModels);
        }

        public IActionResult About(){
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            ViewBag.categories = _categoryrepository.GetAll();
            ViewBag.header = ViewBag.header = _headerrepository.GetById(2);
            return View();
        }
        public IActionResult Contact(Message m){
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            ViewBag.categories = _categoryrepository.GetAll();
            ViewBag.header = _headerrepository.GetById(3);
            
            if(!string.IsNullOrEmpty(m.message)){
                m.date = DateTime.Now;
                if(messageDelivered(m)){
                    ViewBag.notif = "Your Message has been delivered successfully";
                }
                else{
                    ViewBag.notif = "Your Message has NOT been delivered!";
                }
                return View("delivered");
            }
            return View();
        }
        private bool messageDelivered(Message m){
            try
            {
                _messagerepository.Create(m);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public IActionResult Login(string username,string password){
            ViewBag.validate = "none";
            if(!(string.IsNullOrEmpty(username)) && !(string.IsNullOrEmpty(password))){
                if(_logininforepository.Validate(username,password)){
                    ViewBag.header = _headerrepository.GetById(15);
                    admindisplay ="";
                    userdisplay = "none";
                    admin = true;
                    return RedirectToAction("index");
                }
                else{
                    ViewBag.validate = "";
                }
            }
            ViewBag.header = _headerrepository.GetById(16);
            return View();
        }
        public IActionResult Logout(){
            admindisplay ="none";
            userdisplay = "";
            admin = false;
            return RedirectToAction("index");
        }
         public IActionResult Post(int? id,string q,string category){
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            ViewBag.categories = _categoryrepository.GetAll();
            List<Post> allposts =  _postrepository.GetAll();
            if(!string.IsNullOrEmpty(q)){
                List<Post> searchPosts = allposts.Where(i => (_headerrepository.GetById(i.headerId).heading.ToLower().Contains(q))).ToList();
                List<PostViewModel> postViewModels = new List<PostViewModel>();
                foreach (var item in searchPosts)
                {
                    List<string> categorynames = new List<string>();
                    var ids = _postcategoryrepository.GetCategories(item.id);
                    foreach (var catId in ids)
                    {
                        categorynames.Add(_categoryrepository.GetById(catId).name);
                    }
                    var postvm = new PostViewModel(){
                        post= item,
                        categoryNames = categorynames,
                        postHeader = _headerrepository.GetById(item.headerId)
                    };
                    postViewModels.Add(postvm);
                }
                postViewModels =  postViewModels.OrderByDescending(p => p.post.date).ToList();
                ViewBag.header = _headerrepository.GetById(15);
                ViewBag.query = q;
                return View("list",postViewModels);
            }

            if(!string.IsNullOrEmpty(category)){
                var catId= _categoryrepository.GetAll().FirstOrDefault(c => (c.name.Equals(category))).id;
                var searchPostIds = _postcategoryrepository.GetPosts(catId);
                List<PostViewModel> postViewModels = new List<PostViewModel>();
                foreach (var postId in searchPostIds)
                {
                    List<string> categorynames = new List<string>();
                    var ids = _postcategoryrepository.GetCategories(postId);
                    foreach (var cId in ids)
                    {
                        categorynames.Add(_categoryrepository.GetById(cId).name);
                    }
                    var postvm = new PostViewModel(){
                        post= _postrepository.GetById(postId),
                        categoryNames = categorynames,
                        postHeader = _headerrepository.GetById(_postrepository.GetById(postId).headerId)
                    };
                    postViewModels.Add(postvm);
                }
                ViewBag.header = _headerrepository.GetAll().FirstOrDefault(c => (c.heading.Equals(category)));
                postViewModels =  postViewModels.OrderByDescending(p => p.post.date).ToList();
                return View("list",postViewModels);
            }

            PostViewModel pvm ;
            if(id!= null){
                Post p = allposts.FirstOrDefault(p=>p.id == id);
                var Comments = _commentRepository.GetPostComments(p.id);
                pvm = new PostViewModel(){
                    post = p,
                    comments = Comments
                }; 
                ViewBag.commentCount = Comments.Count;
                ViewBag.header = _headerrepository.GetById(p.headerId);
                p.viewCount++;
                _postrepository.Update(p);
            }

            else{
                Random rastgele = new Random();
                int sayi = rastgele.Next(allposts.Count);
                Post p = allposts[sayi];
                var Comments = _commentRepository.GetPostComments(p.id);
                pvm = new PostViewModel(){
                    post = p,
                    comments = Comments
                };
                ViewBag.commentCount = Comments.Count;
                ViewBag.header = _headerrepository.GetById(p.headerId);
                p.viewCount++;
                _postrepository.Update(p);
            }
            return View("post",pvm);
        }
        public IActionResult filter(string start,string end){
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            ViewBag.categories = _categoryrepository.GetAll();
            ViewBag.header = _headerrepository.GetById(15);
            List<Post> allposts =  _postrepository.GetAll();
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            DateTime başlangıç;
            DateTime bitiş;
            try
            {
               başlangıç = Convert.ToDateTime(start);
               bitiş =  DateTime.MaxValue;
               if(!string.IsNullOrEmpty(end) ){
                    bitiş = Convert.ToDateTime(end);
                }
            }
            catch (System.Exception)
            {
                return View("list",postViewModels);
            }

            if(!string.IsNullOrEmpty(start) )  {
                List<Post> searchPosts;
                if(!string.IsNullOrEmpty(start)){
                    searchPosts = allposts.Where(p => (p.date.CompareTo(başlangıç)==1 & p.date.CompareTo(bitiş)==-1)).ToList();
                }
                else{
                    searchPosts = allposts.Where(p => (p.date.CompareTo(başlangıç)==1)).ToList();
                }
                
                foreach (var item in searchPosts)
                {
                    List<string> categorynames = new List<string>();
                    var ids = _postcategoryrepository.GetCategories(item.id);
                    foreach (var catId in ids)
                    {
                        categorynames.Add(_categoryrepository.GetById(catId).name);
                    }
                    var postvm = new PostViewModel(){
                        post= item,
                        categoryNames = categorynames,
                        postHeader = _headerrepository.GetById(item.headerId)
                    };
                    postViewModels.Add(postvm);
                }
                ViewBag.header = _headerrepository.GetById(15);
                
            }
            
            postViewModels =  postViewModels.OrderByDescending(p => p.post.date).ToList();
            return View("list",postViewModels);
        }

        public IActionResult makeComment(int postId,Comment c){
            ViewBag.categories = _categoryrepository.GetAll();
            ViewBag.admin = admindisplay;
            ViewBag.user = userdisplay;
            c.date = DateTime.Now;
            _commentRepository.Create(c);   
            Post p = _postrepository.GetById(postId);
            var Comments = _commentRepository.GetPostComments(p.id);
            PostViewModel pvm = new PostViewModel(){
                post = p,
                comments = Comments
            }; 
            ViewBag.commentCount = Comments.Count;
            ViewBag.header = _headerrepository.GetById(p.headerId);
            return View("post",pvm);
        }

        public IActionResult newpost(PostViewModel pvm){
            if(!admin){
                return View("error");
            }
            
            if(pvm.categoryNames == null){
                ViewBag.admin = admindisplay;
                ViewBag.user = userdisplay;
                ViewBag.categories = _categoryrepository.GetAll();
                ViewBag.header = ViewBag.header = _headerrepository.GetById(17);
                return View();
            }
            _headerrepository.Create(pvm.postHeader);
            pvm.post.date = System.DateTime.Now;
            pvm.post.headerId = pvm.postHeader.id;
            pvm.post.viewCount = 0;
            _postrepository.Create(pvm.post);
            foreach (var item in pvm.categoryNames)
            {
                PostCategory pc = new PostCategory();
                pc.post = pvm.post;
                pc.category =_categoryrepository.GetAll().Where(c => c.name == item).ToList()[0];
                _postcategoryrepository.Create(pc);
            }
            return RedirectToAction("index");
        }

        public IActionResult Deletepost(int id){
            if(!admin){
                return View("error");
            }
            try
            {
                _postrepository.Delete(_postrepository.GetById(id));
                return RedirectToAction("index");
            }
            catch (System.Exception)
            {
                return View("error");
            }
        }
        public IActionResult Updatepost(int id){
             if(!admin){
                return View("error");
            }
            try
            {
                _postrepository.Update(_postrepository.GetById(id));
                return RedirectToAction("post/"+id);
            }
            catch (System.Exception)
            {
                return View("error");
            }
        }

        public IActionResult Deletecomment(int id){
             if(!admin){
                return View("error");
            }
            try
            {
                var comment = _commentRepository.GetById(id);
                int postid = comment.PostId;
                _commentRepository.Delete(comment);
                return Post(postid,null,null);
            }
            catch (System.Exception)
            {
                return View("error");
            }
        }
        private void popularposts (){
            var popularPostsofMonth = _postrepository.GetPopularPostOfThisMonth();
            List<Header> headers = new List<Header>();
            List<string> difference = new List<string>();
            foreach (var item in popularPostsofMonth)
            {
                int dif = System.DateTime.Now.Day-item.date.Day;
                if(dif == 0){
                    difference.Add("Today");
                }
                else if(dif ==1){
                    difference.Add("Yesterday");
                }
                else{
                    difference.Add(dif+" days ago");
                }
                headers.Add(_headerrepository.GetById(item.headerId));
            }

            ViewBag.monthsPosts = new PopularPostsModel(){
                postids = popularPostsofMonth.Select(p=>p.id).ToList(),
                popularposts = headers,
                daydifference = difference
            };

            var popularPostsofAllTimes = _postrepository.GetPopularPostOfAllTimes();
            List<Header> headers2 = new List<Header>();
            List<string> difference2 = new List<string>();
            foreach (var item in popularPostsofAllTimes){
                var fark= System.DateTime.Now - item.date;
                var gün = fark.Days;
                if( gün < 1){
                    difference2.Add("Today");
                }
                else if(gün == 1){
                    difference2.Add("Yesterday");
                }
                else if(gün < 30){
                    difference2.Add(gün+" days ago");
                }
                else if(gün < 60){
                    difference2.Add("1 month ago");
                }
                else if(gün < 365){
                    difference2.Add((int)gün/30 + " months ago");
                }
                else if(gün < 730){
                    difference2.Add("1 year ago");
                }
                else{
                     difference2.Add((int)gün/365 + " years ago");
                }  

                headers2.Add(_headerrepository.GetById(item.headerId));
            }

            ViewBag.alltimesPosts = new PopularPostsModel(){
                postids = popularPostsofAllTimes.Select(p=>p.id).ToList(),
                popularposts = headers2,
                daydifference = difference2
            };
        }
    }
}