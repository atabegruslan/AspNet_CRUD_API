using System.Web.Mvc;

// https://www.youtube.com/watch?v=LStRA6qUAks&list=PL6n9fhu94yhVm6S8I2xd6nYz2ZORd7X2v&index=79
// https://www.tutorialsteacher.com/mvc/area-in-asp.net-mvc
// https://stackoverflow.com/questions/43341935/visual-studio-2017-2019-add-areas-missing

namespace TravelBlog.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}