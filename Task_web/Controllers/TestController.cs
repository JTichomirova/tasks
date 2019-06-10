using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_web.Models;
using Task_web.DAL;

namespace Task_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMyRepository<TestModel> _myRepository;

        public TestController(IMyRepository<TestModel> myRepository)
        {
            _myRepository = myRepository;
        }

        /*
         *
         * необходимо релизовать CRUD для testModels
         *
         */

        [HttpGet]
        // [Route("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<TestModel> tests = _myRepository.GetAll();
            return Ok(tests);
        }

        [HttpGet("{id}")]
        //[Route("GetById")]
        public IActionResult GetById(Guid id)
        {
            var testModel = _myRepository.GetById(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return Ok(testModel);
        }

        [HttpPost]
        [Route("CreateTestM")]
        public ActionResult CreateTestM(TestModel testModel)
        {
            _myRepository.AddEntity(testModel);
            _myRepository.SaveEntity();
            return Ok();
        }

        [HttpPost]
        [Route("UpdateTestM")]
        public ActionResult UpdateTestM(TestModel testModel)
        {
            var data = _myRepository.GetById(testModel.Id);
            if (data != null)
            {
                data.Name = testModel.Name;
                data.Id = testModel.Id;
            }
            _myRepository.SaveEntity();
            return Ok();
        }

        [HttpPost]
        [Route("DeleteTestM")]
        public ActionResult DeleteTestM(TestModel testModel)
        {
            var tm = _myRepository.GetById(testModel.Id);
            _myRepository.DeleteEntity(tm);
            _myRepository.SaveEntity();
            return Ok();
        }

    }
}
