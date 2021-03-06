
GO
/****** Object:  StoredProcedure [dbo].[GetDataForSalesReport]    Script Date: 04/01/2019 08:31:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[GetDataForSalesReport_1Apr2019] '01/04/2019','01/04/2019'
--[GetDataForSalesReport] '01/04/2019','01/04/2019'
ALTER proc [dbo].[GetDataForSalesReport]
@FromDate varchar(20),
@ToDate varchar(20)
as
begin


IF EXISTS (select top 1 BillNumber from SalesMaster sm1 where sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1)
begin
declare @fromBill varchar(10),@toBill varchar(10)
set @fromBill=(select cast(MIN(BillNumber) as varchar) from SalesMaster sm where sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1)
set @toBill=(select cast(MAX(BillNumber) as varchar) from SalesMaster sm where sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1);



with Tempt (FromDate,ToDate,InvoiceFT,Paymentmode, TotalfoodSale, CGST,SGST,TotalAmount,RoundOffAmount,SGSCTRate,CGSTRate) 
As
(

select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '1' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CASH' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CASH' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  
  union
  
  select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '2' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CARD' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CARD' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  
  union
  
 select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '3' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.Status=6 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.Status=6 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1 where isnull(t1.TotalfoodSale,0) <> 0
  
  union
  
select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '4'PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1

 union
  
  select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '2' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CREDIT' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CREDIT' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  
  )
  select * from Tempt where TotalfoodSale > 0
  end 
  else
  begin
  select * from SalesMaster where 1=2
  end



end
