using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;

        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseService.GetEntityById(id);
            return Ok(entity);
        }

        // POST api/<BaseEntityController>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var serviceResult = _baseService.Add(entity);
            if(serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }else
                return Ok(serviceResult);
        }

        // PUT api/<BaseEntityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if(keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if(keyProperty.PropertyType == typeof(int)){
                keyProperty.SetValue(entity, Int32.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }
            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
                return Ok(serviceResult);
        }

        // DELETE api/<BaseEntityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            return Ok(res);
        }
    }
}
