<Query Kind="Expression">
  <Connection>
    <ID>7cc90568-9aaf-466a-abc4-a336dce76db3</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>NORTHWND</Database>
  </Connection>
</Query>

Products.Select (p => new 
	{
		p = p, 
		spanishOrders = p.OrderDetails.Where (o => (o.Order.ShipCountry == "Spain"))
	})
	.Where (t => t.spanishOrders.Any ())
	.OrderBy (t => t.p.ProductName)
   	.Select (t => new  
    	{
        	ProductName = t.p.ProductName, 
            CategoryName = t.p.Category.CategoryName, 
            Orders = t.spanishOrders.Count (), 
            TotalValue = t.spanishOrders.Sum (o => (o.UnitPrice * o.Quantity))
        })
   
/*
from p in Products
let spanishOrders = p.OrderDetails.Where (o => o.Order.ShipCountry == "Spain")
where spanishOrders.Any()
orderby p.ProductName
select new
{
	p.ProductName,
	p.Category.CategoryName,
	Orders = spanishOrders.Count(),	
	TotalValue = spanishOrders.Sum (o => o.UnitPrice * o.Quantity)
}
*/