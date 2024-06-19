
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X01.Model.Identity;
using SkladApi.Model;
using SkladDB;


namespace SkladApi.Controllers;

[ApiController]
//  [Authorize(Roles = X01Roles.Admin + "," + X01Roles.Manager)]
[Route("api/[controller]/[action]")]
public class CustomerController: ControllerBase
{
        private readonly SkaldDBContext _db;

        public CustomerController(SkaldDBContext db)
        {
            _db = db;
        }


        [HttpGet("{owner_id}")]        
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {



            var articles = await (from b in _db.Клиентs
                                 
                                  select new CustomerDto()
                                  {
                                      Id = b.Id,
                                      Псевдоним= b.Псевдоним,
                                      Фио=b.Фио,
                                      Город=b.Город,
                                      Телефон=b.Телефон,
                                      ПределКредита=b.ПределКредита                                      
                                       
                                      
                                  }).ToListAsync();

            if (articles == null) return NotFound();

            return Ok(articles);


        }

        [HttpGet("{owner_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetForProduct_type(string  owner_id, int product_type_id)
        {
            // int i = 0;
            var articles = await (from item in _db.Articles
                                  where  item.OwnerId==owner_id &&  item.Product_typeId ==  product_type_id
                                  select new ArticleDto()
                                  {
                                      Id = item.Id,
                                      OwnerId=item.OwnerId,
                                      Name = item.Name,
                                      
                                      Product_typeId = item.Product_typeId,
                                      Hidden = item.Hidden
                                  }).ToListAsync();
            if (articles == null)return NotFound();

            return Ok(articles);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ArticleDto>> GetItem(int id)
        {
            var item = await _db.Articles!.Select(d => new ArticleDto
            {
                Id = d.Id,
                 OwnerId=d.OwnerId,
                Name = d.Name,                
                Product_typeId = d.Product_typeId,
                Hidden = d.Hidden
            }
            )
            .SingleOrDefaultAsync(c => c.Id == id);

            if (item == null) return NotFound();

            return Ok(item);
            
        }

        
        //  (post) создать
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<ArticleDto>> Create(Article item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            _db.Articles!.Add(item);
            await _db.SaveChangesAsync();



            var dto = new ArticleDto()
            {
                Id = item.Id,
                Name = item.Name,
                OwnerId=item.OwnerId,
               
                Product_typeId = item.Product_typeId,
                Hidden = item.Hidden
            };

            return CreatedAtRoute("GetItem", new { id = item.Id }, dto);

        }


        

        // (put) -изменить
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Update(int id, Article item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            _db.Entry(item).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //204


        }
      
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Article>> Delete(int id)
        {


            Article? item = await _db.Articles!.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Articles.Remove(item);
            await _db.SaveChangesAsync();
            return Ok(item);

        }

        private bool ArticleExists(int id)
        {
            return _db.Articles!.Count(e => e.Id == id) > 0;
        }
    }
}


