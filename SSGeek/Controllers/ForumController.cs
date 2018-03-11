using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;
using SSGeek.Models;

namespace SSGeek.Controllers
{
    public class ForumController : Controller
    {

        IForumPostDAL dal;
        public ForumController(IForumPostDAL dal)
        {
            this.dal = dal;
        }
        
        
        // GET: Forum
        public ActionResult Forum()
        {

            List<ForumPost> list = dal.GetAllPosts();

            return View("Forum", list);
        }

        
        public ActionResult ForumPost()
        {
            return View("ForumPost");
        }

        [HttpPost]
        public ActionResult ForumPost(ForumPost model)
        {
            dal.SaveNewPost(model);
            return RedirectToAction("Forum");

        }



    }
}