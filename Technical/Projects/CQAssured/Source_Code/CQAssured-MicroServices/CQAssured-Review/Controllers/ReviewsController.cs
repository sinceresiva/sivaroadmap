using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CQAssured_Review.Models;
namespace CQAssured_Review.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        static List<Review> reviewsList = new List<Review>{
                                            new Review{Id=1},
                                            new Review{Id=2},
                                            new Review{Id=3}
                                        };
        // GET api/values
        [HttpGet]
        public async Task<List<Review>> Get()        
        {           
            List<Review> result = null; 
            await Task.Run(()=>{
                result= ReviewsController.reviewsList;
            });          
            return result;  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Review Get(int id)
        {
            Review matchedReview = null; 
            matchedReview = ReviewsController.reviewsList.Find(r => r.Id.Equals(id));
            return matchedReview;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
