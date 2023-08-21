using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Entities.Dtos;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //IProductsService _productsService;
        private IProductsService _productsService;
        private readonly IProductsDal _productsDal;

        public ProductsController(IProductsService productService, IProductsDal productsDal)
        {
            _productsService = productService;
            _productsDal = productsDal;
            
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain

            //Thread.Sleep(1000);

            //return Ok(dbContext.Products.ToList());

            var result = _productsService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productsService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Products products)
        {
            var result = _productsService.Add(products);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        //[HttpDelete("delete")]
        //public IActionResult Delete(Products products)
        //{
        //    var result = _productsService.Delete(products);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToDelete = _productsDal.Get(p => p.Id == id);
            if (productToDelete == null)
            {
                return NotFound(new { message = Messages.ProductNotFound });
            }

            _productsDal.Delete(productToDelete);
            return Ok(new { message = Messages.ProductDeleted });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Products updatedProduct)
        {
            var productToUpdate = _productsDal.Get(p => p.Id == id);
            if (productToUpdate == null)
            {
                return NotFound(new { message = Messages.ProductNotFound });
            }
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.NumberOfProduct = updatedProduct.NumberOfProduct;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.CreatedDate = updatedProduct.CreatedDate;
            productToUpdate.CreatedUserId = updatedProduct.CreatedUserId;
            productToUpdate.IsActive = updatedProduct.IsActive;
            productToUpdate.IsDeleted = updatedProduct.IsDeleted;

            _productsDal.Update(productToUpdate);

            return Ok(new { message = Messages.ProductUpdated });
        }


        //public IActionResult Update(int id)
        //{
        //    var productToUpdate = _productsDal.Get(p => p.Id == id);
        //    if (productToUpdate == null)
        //    {
        //        return NotFound(new { message = Messages.ProductNotFound });
        //    }

        //    _productsDal.Update(productToUpdate);
        //    return Ok(new { message = Messages.productdeleted });
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id)
        //{

        //}

        //[HttpPut("update")]
        //public IActionResult Update(Products products)
        //{
        //    var result = _productsService.Update(products);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }

        //    return BadRequest(result.Message);
        //}


        //çalışır gibbi oldu ama çalışmıyor
        //[HttpPut("{id}")]
        //public  IActionResult Update(Products products, int id)
        //{
        //    //using var context = new CustomerRelationshipManagementContext();

        //    if (id != products.Id)
        //        return BadRequest("Geçersiz Id");

        //    //var product = context.Products.Find(products.Id);
        //    _customerRelationshipManagementContext.Entry(products).State = EntityState.Modified;
        //    try
        //    {
        //         _customerRelationshipManagementContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if(!ProductsExits(id))
        //        { return NotFound(); }
        //        else { throw; }
        //    }
        //    return NoContent();
        //}
        //private bool ProductsExits(long id)
        //{
        //    return (_customerRelationshipManagementContext.Products?.Any(p => p.Id == id)).GetValueOrDefault();
        //}

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<Products>> UpdateProducts(int id, Products products)
        //{
        //    try
        //    {
        //        if (id != products.Id)
        //            return BadRequest("Products ID mismatch");

        //        var productsToUpdate =  _productsService.GetById(id);

        //        if (productsToUpdate == null)
        //            return NotFound($"Products with Id = {id} not found");

        //        return _productsService.UpdateProducts(products);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error updating data");
        //    }
        //}

        //[HttpPut("update/{id}")]
        //public IActionResult Update(int id, [FromBody] ProductUpdateModel updateModel)
        //{
        //    // ID'ye göre güncellenecek ürünü veritabanından çekin
        //    var existingProduct = _productsService.GetById(id);
        //    if (existingProduct == null)
        //    {
        //        return NotFound(new { message = "Ürün bulunamadı." });
        //    }

        //    // Güncelleme için gerekli kontrolleri yapabilirsiniz.
        //    existingProduct.Name = updateModel.Name;
        //    existingProduct.NumberOfProduct = updateModel.NumberOfProduct;
        //    existingProduct.Price = updateModel.Price;
        //    existingProduct.Description = updateModel.Description;
        //    // Diğer güncellenecek özellikleri de buraya ekleyebilirsiniz.

        //    // Güncelleme işlemini yapmak için _productsService'deki Update metodunu çağırın
        //    var result = _productsService.Update(existingProduct);
        //    if (result.Success)
        //    {
        //        return Ok(new { message = "Ürün güncellendi." });
        //    }

        //    return BadRequest(new { message = "Ürün güncellenirken hata oluştu." });
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] Products updateModel)
        //{
        //    var existingProduct = _productsService.GetById(id);
        //    if (existingProduct == null)
        //    {
        //        return NotFound(new { message = "Ürün bulunamadı." });
        //    }

        //    // Güncelleme için gerekli kontrolleri yapabilirsiniz.
        //    existingProduct.Name = updateModel.Name;
        //    existingProduct.NumberOfProduct = updateModel.NumberOfProduct;
        //    existingProduct.Price = updateModel.Price;
        //    existingProduct.Description = updateModel.Description;
        //    // Diğer güncellenecek özellikleri de buraya ekleyebilirsiniz.

        //    var result = _productsService.Update(existingProduct);
        //    if (result.Success)
        //    {
        //        return Ok(new { message = "Ürün güncellendi." });
        //    }

        //    return BadRequest(new { message = "Ürün güncellenirken hata oluştu." });
        //}
    }
}
