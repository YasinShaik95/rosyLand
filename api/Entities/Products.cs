namespace api;

public class Products
{
  public int Id { get; set; }
  public int ProductTypeId { get; set; }
  public string ProductName { get; set; }
  public string ProductDescription { get; set; }
  public int ProductShapeId { get; set; }
  public int ProductSizeId { get; set; }
  public ProductType ProductType { get; set; }
  public ProductSize ProductSize { get; set; }
  public ProductShape ProductShape { get; set; }

}
