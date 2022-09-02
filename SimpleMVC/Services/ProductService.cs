using SimpleMVC.Interfaces;

namespace SimpleMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext context)
        {
            _context = context;
        }


        public Product GetOne(int id)
        {
            var product = _context.products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.products.ToList();
            return products;
        }

        public void CreateNew(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            var productToDelet = _context.products.FirstOrDefault(x => x.Id == id);
            _context.products.Remove(productToDelet);
            _context.SaveChanges();
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productToUpdate = _context.products.First(x => x.Id == id);
            productToUpdate.Name = product.Name;
            productToUpdate.price = product.price;
            _context.products.Update(productToUpdate);
            _context.SaveChanges();
            return productToUpdate;
        }
    }
}
