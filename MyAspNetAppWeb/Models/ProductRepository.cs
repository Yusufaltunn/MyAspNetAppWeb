namespace MyAspNetAppWeb.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        { 

        };


        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"bu id({id}) ye sahip ürüm bulunmamaktadır");
            }

            _products.Remove(hasProduct);
        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);


            if (hasProduct == null)
            {
                throw new Exception($"bu id({updateProduct.Id}) ye sahip ürüm bulunmamaktadır");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;



        }
    }
}
