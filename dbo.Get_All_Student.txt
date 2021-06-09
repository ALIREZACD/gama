CREATE PROCEDURE [dbo].[Get_All_Student]
	
AS
begin
	Select
	ROW_NUMBER()over (order by tbl001_Student.fName asc) as [شماره ردیف] ,
	tbl001_Student.fName as [نام ],
	tbl001_Student.lName as [نام خانوادگی],
	tbl001_Student.nCode as [شماره ملی],
	tbl001_Student.nationalCode as[کد ملی],
	tbl001_Student.Gender as[جنسیت],
	tbl001_Student.Married as [وضعیت تاهل],
	tbl001_Student.issuePlace as [محل صدور شناسنامه],
	tbl001_Student.birthDate as[تاریخ تولد],
	tbl001_Student.Father as[نام پدر],
	tbl001_Student.Mother as[نام مادر],
	tbl001_Student.Education as[تحصیلات],
	tbl001_Student.Tel as[تلفن],
	tbl001_Student.Mobile as[موبایل],
	tbl001_Student.TelegramNumber as [شماره تلگرام],
	tbl001_Student.StudentJob as[شغل کارآموز],
	tbl001_Student.Address as [آدرس],
	tbl001_Student.PostalCode as [کد پستی],
	tbl001_Student.Email as [آدرس ایمیل],
	tbl001_Student.Pic as [عکس کارآموز],
	tbl001_Student.Signature as[امضا کارآموز]
	from 
	tbl001_Student;
	end
