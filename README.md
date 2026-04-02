Sam running his grocery shop. He is fed up with his manual billing system. As a software developer he needs your help to automate the billing system.
Requirement’s:
1) Sam can login by using admin with password admin@1234#$!
2) Sam can able to add the products, update the products and delete the products.
3) Sam can add the customer and update the customer details.
4) When Sam generates Bill against any customer the qty mentioned by the customer should be deducted from the Product master table qty column.
5) Note: Qty column in product master table is the qty available in his shop and the qty mentioned in the Bill Details table is the qty required by the customer. 





Create Following Tables..                  
////****CustomerMaster****//////                              
CustID  | int(pk)                        
CustName| varchar(50)                                 
Address| varchar(50)                                                     
Mobile Number | varchar(10)                                                  

////****ProductMaster*****///                    
ProdID| int(pk)                                                  
ProdName | varchar(50)                                                           
Price |int                                         
Qty |int                                    

////****BillDetails****///                                 
BillNo | int                              
CustID | int(fk)                                       
ProdID | int(fk)                         
Qty | int                  
Total_Bill | int                       










