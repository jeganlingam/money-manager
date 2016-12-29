--Validations
--1) To validate all transactions have customcategory set
select * from transactionsstaging where customcategory is null

--2) To make grouping looks fine
select description,customcategory,count(*) from transactionsstaging
group by description, customcategory
order by description

--3) Check all credit transactions
select description descr, customcategory, originaldescription, amount,transactiontype,category,transactiondate,* from transactionsstaging where transactiontype = 'credit'
order by description

-- Final
--INSERT INTO Transactions SELECT * FROM TransactionsStaging

-- Create views
IF OBJECT_ID ('transactions_view', 'V') IS NOT NULL  
DROP VIEW transactions_view ;  
GO  
CREATE VIEW transactions_view  
AS   
select t.*, dateadd(month,datediff(month,0,transactiondate),0) as TransactionMonth, b.Amount as Budget from transactions t, budget b
where t.CustomCategory = b.CustomCategory
GO  

  -- Create views
IF OBJECT_ID ('IncomeExpense_view', 'V') IS NOT NULL  
DROP VIEW IncomeExpense_view ;  
GO  
CREATE VIEW IncomeExpense_view  
AS   
SELECT * FROM
  Transactions_View where CustomCategory not in('transfer', 'refund', 'Credit Card Payment')
GO  
 

  -- Create views
IF OBJECT_ID ('Expense_view', 'V') IS NOT NULL  
DROP VIEW Expense_view ;  
GO  
CREATE VIEW Expense_view  
AS   
SELECT * FROM
  Transactions_View where CustomCategory not in('transfer', 'refund', 'Credit Card Payment') and TransactionType = 'debit'
GO  
 
    -- Create views
IF OBJECT_ID ('Savings_view', 'V') IS NOT NULL  
DROP VIEW Savings_view ;  
GO  
CREATE VIEW Savings_view  
AS   
  select a.TransactionMonth, b.IncomeAmount - a.ExpenseAmount as Savings from 
  (SELECT Sum(Amount) ExpenseAmount, TransactionMonth FROM
  Transactions_View where CustomCategory not in('transfer', 'refund', 'Credit Card Payment')
  and TransactionType = 'debit'
  group by TransactionMonth) a,
  (SELECT Sum(Amount) IncomeAmount, TransactionMonth FROM
  Transactions_View where CustomCategory not in('transfer', 'refund', 'Credit Card Payment')
  and TransactionType = 'credit'
  group by TransactionMonth) b
  where a.TransactionMonth = b.TransactionMonth
GO  


  -- Create views
IF OBJECT_ID ('assets_view', 'V') IS NOT NULL  
DROP VIEW assets_view ;  
GO  
CREATE VIEW assets_view
AS   
select *,dateadd(month,datediff(month,0,transactiondate),0) as TransactionMonth from assets
GO  

  -- Create views
IF OBJECT_ID ('accounts_latest', 'V') IS NOT NULL  
DROP VIEW accounts_latest ;  
GO  
CREATE VIEW accounts_latest
AS   
select * from
(select *, dateadd(month,datediff(month,0,transactiondate),0) as TransactionMonth from accounts) a
Where a.TransactionMonth in 
(select dateadd(month,datediff(month,0,max(transactiondate)),0) from accounts)
and AccountName not in ('First Tech - Savings', 'First Tech - Checking', 'Fidelity - ESPP', 'PayPal Account')
GO  


select * from savings_view
select * from accounts
select * from accounts_latest

--delete from accounts Where dateadd(month,datediff(month,0,transactiondate),0) in (select dateadd(month,datediff(month,0,max(transactiondate)),0) from accounts)



SELECT * FROM
  Transactions_View where CustomCategory not in('transfer', 'refund', 'Credit Card Payment') and TransactionType = 'debit'
  order by description, customcategory



	select * from Transactions
	select count(*), description, originaldescription, amount, transactiondate,accountName from Transactions
	group by description, originaldescription, amount ,transactiondate, accountName
	having count(*) > 1

	select * from transactions where accountName = 'Bank of America Business Mastercard'

	select distinct customcategory from transactions

-- Create views
IF OBJECT_ID ('budget_view', 'V') IS NOT NULL  
DROP VIEW budget_view ;  
GO  
CREATE VIEW budget_view  
AS   
select * from budget
GO  