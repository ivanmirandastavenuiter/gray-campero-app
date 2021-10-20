namespace GC.Dtos
{
    public class ProductReadDto
    {    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public float Price { get; set; }
        public int Stock { get; set; }  
        public string UrlPath { get; set; }

    }
}