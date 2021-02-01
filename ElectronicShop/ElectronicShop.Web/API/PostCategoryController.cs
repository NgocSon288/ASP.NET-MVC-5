using AutoMapper;
using ElectronicShop.Model.Models;
using ElectronicShop.Service;
using ElectronicShop.Web.Infrastructure.Core;
using ElectronicShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElectronicShop.Web.Infrastructure.Extensions;

namespace ElectronicShop.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;  
                var listCategory = _postCategoryService.GetAll();

                var listCategoryVM = Mapper.Map<IEnumerable<PostCategoryViewModel>>(listCategory);


                response = request.CreateResponse(HttpStatusCode.OK, listCategory); 
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryvm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryvm);

                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryvm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryvm);

                    _postCategoryService.Update(postCategory);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}