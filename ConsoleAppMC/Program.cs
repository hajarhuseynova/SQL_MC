
using System.Data.SqlClient;


string connection= "Server=DESKTOP-609D4KS;Database=MC;Trusted_Connection=True";
SqlConnection sqlConnection = new SqlConnection(connection);

bool IsReady = true;
Console.WriteLine("1.Create Product");
Console.WriteLine("2.ShowAllProducts");
Console.WriteLine("3.Update Product");
Console.WriteLine("4.GetProductById");
Console.WriteLine("5.Create Category");
Console.WriteLine("6.ShowAllCategories");
Console.WriteLine("7.Update Category");
Console.WriteLine("8.GetCategoryById");
Console.WriteLine("9.Clear");
Console.WriteLine("0.Quit");
int.TryParse(Console.ReadLine(), out int request);
while (IsReady)
{
    switch (request)
    {
        case 0:
            return;
        case 1:
            CreateProduct();
            break;
        case 2:
            ShowAllProducts();
            break;
        case 3:
        UpdateProduct();
            break;
        case 4:
            GetProductById();
            break;
        case 5:
            CreateCategory();   
            break;
        case 6:
            ShowAllCategories();
            break;
        case 7:
            UpdateCategory();
            break;
        case 8:
           GetCategoryById();
            break;
        case 9:
            Console.Clear();
            break;
        default:
            Console.WriteLine("Enter Valid Option");
            break;
    }
    Console.WriteLine("1.Create Product");
    Console.WriteLine("2.ShowAllProducts");
    Console.WriteLine("3.Update Product");
    Console.WriteLine("4.GetProductById");
    Console.WriteLine("5.Create Category");
    Console.WriteLine("6.ShowAllCategories");
    Console.WriteLine("7.Update Category");
    Console.WriteLine("8.GetCategoryById");
    Console.WriteLine("9.Clear");
    Console.WriteLine("0.Quit");
    int.TryParse(Console.ReadLine(), out request);
}
void CreateProduct()
{
    Console.WriteLine("Enter Product's Name:");
    string name=Console.ReadLine();
    Console.WriteLine("Enter Category's Id");
    int.TryParse(Console.ReadLine(), out int categoryId);
    SqlCommand cmd =new SqlCommand($"INSERT INTO Products VALUES('{name}', '{categoryId}')",sqlConnection);
    sqlConnection.Open();
    cmd.ExecuteNonQuery();
    sqlConnection.Close();
}
void ShowAllProducts()
{
    SqlCommand cmd = new SqlCommand($"select * FROM Products", sqlConnection);
    sqlConnection.Open();
    var result=cmd.ExecuteReader();
    while (result.Read())
    {
        Console.WriteLine(result["Id"]+"."+result["Name"]);
    }
    sqlConnection.Close();
}
void UpdateProduct()
{
    Console.WriteLine("Enter Product's Id");
    int.TryParse(Console.ReadLine(), out int Id);
    SqlCommand cmd1 = new SqlCommand($"Select * FROM Products where Id={Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader= cmd1.ExecuteReader();
    if (reader.Read())
    {
        sqlConnection.Close();
        sqlConnection.Open();
        Console.WriteLine("Update Product's Name");
        SqlCommand cmd2 = new SqlCommand ($"UPDATE Products SET Name = '{Console.ReadLine()}' WHERE Id = {Id}; ", sqlConnection);
        cmd2.ExecuteNonQuery();
    }
    else
    {
        Console.WriteLine("Product is not found");
    }
    sqlConnection.Close(); 
}
void GetProductById()
{
    Console.WriteLine("Enter Product's Id");
    int.TryParse(Console.ReadLine(), out int Id);

    SqlCommand cmd1 = new SqlCommand($"Select * FROM Products where Id = {Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    bool status = false;
    while (reader.Read())
    {
        Console.WriteLine(reader["Id"] + "." + reader["Name"]);
        status = true;
    }
    if (!status)
    {
        Console.WriteLine("Product is not found");
    }
    sqlConnection.Close();
}
void CreateCategory()
{
    Console.WriteLine("Enter Category's Name:");
    string name = Console.ReadLine();
    SqlCommand cmd = new SqlCommand($"INSERT INTO Categories VALUES('{name}')", sqlConnection);
    sqlConnection.Open();
    cmd.ExecuteNonQuery();
    sqlConnection.Close();
}
void ShowAllCategories()
{
    SqlCommand cmd = new SqlCommand("SELECT C.Id 'CategoryId', C.Name 'CategoryName',P.Name 'ProductName' FROM Categories as C LEFT JOIN Products as P ON C.Id=P.CategoryId", sqlConnection);
    sqlConnection.Open();
    var result = cmd.ExecuteReader();
    while (result.Read())
    {
        Console.WriteLine(result["CategoryId"] + "."+ result["CategoryName"]+"-->"+result["ProductName"]);
    }
    sqlConnection.Close();
}
void UpdateCategory()
{
    Console.WriteLine("Enter Category's Id");
    int.TryParse(Console.ReadLine(), out int Id);
    SqlCommand cmd1 = new SqlCommand($"Select * FROM Categories where Id={Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    if (reader.Read())
    {
        sqlConnection.Close();
        sqlConnection.Open();
        Console.WriteLine("Update Category's Name");
        string name = Console.ReadLine();
        SqlCommand cmd2 = new SqlCommand($"UPDATE Categories SET Name = '{name}' WHERE Id = {Id}; ", sqlConnection);
        cmd2.ExecuteNonQuery();
    }
    else
    {
        Console.WriteLine("Category is not found");
    }
    sqlConnection.Close();
}
void GetCategoryById()
{
    Console.WriteLine("Enter Category's Id");
    int.TryParse(Console.ReadLine(), out int Id);

    SqlCommand cmd1 = new SqlCommand($"Select * from Categories where Id = {Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    bool status = false;
    while (reader.Read())
    {
        Console.WriteLine(reader["Id"] + "." + reader["Name"]);
        status = true;
    }
    if (!status)
    {
        Console.WriteLine("Category is not found");
    }
    sqlConnection.Close();
}