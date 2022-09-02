namespace SimpleMVC.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetOne(int id);
        void CreateNew(Product product);
        void deleteProduct(int id);
        Product UpdateProduct(int id, Product product);

    }
}
