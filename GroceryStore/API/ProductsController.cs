using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GroceryStore.Models;

namespace GroceryStore.API
{
    public class ProductsController : ApiController
    {
        private GroceryModelContext db = new GroceryModelContext();

        // GET: api/Products
        public IQueryable<ProductsDTO> GetProducts()
        {
            var products = from p in db.Products
                           select new ProductsDTO()
                           {
                               ProductsId = p.ProductsId,
                               productName = p.productName,
                               productExpiry = p.productExpiry,
                           };
            return products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductsDTO))]
        public async Task<IHttpActionResult> GetProducts(int id)
        {
            Products p = await db.Products.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            ProductsDTO products = new ProductsDTO
            {
                ProductsId = p.ProductsId,
                productName = p.productName,
                productExpiry = p.productExpiry,
            };

            return Ok(products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProducts(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.ProductsId)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Products))]
        public async Task<IHttpActionResult> PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = products.ProductsId }, products);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Products))]
        public async Task<IHttpActionResult> DeleteProducts(int id)
        {
            Products products = await db.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            await db.SaveChangesAsync();

            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int id)
        {
            return db.Products.Count(e => e.ProductsId == id) > 0;
        }
    }
}