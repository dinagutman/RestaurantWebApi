using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Repositories.Repositories;
using ServiceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;

namespace RestaurantWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class OrderController : ControllerBase
  {
    IOrdersService orderService;
    IOrderDetailsService orderDetailsService;
    IEmployeeService employeeService;
    public OrderController(IOrdersService orderService, IOrderDetailsService orderDetailsService, IEmployeeService employeeService)
    {
      //Dependency Injection
      this.orderService = orderService;
      this.orderDetailsService = orderDetailsService;
      this.employeeService = employeeService;
    }
    [HttpGet("getOrderCodeByTableCode/{tableCode}")]
    public int GetOrderCodeByTableCode(int tableCode)
    {
      return orderService.GetOrderCodeByTableCode(tableCode);
    }

    [HttpGet("GetAllOrders")]
    public List<Orders> GetAllOrders()
    {
      return orderService.GetAllOrders();
    }

    [HttpGet("GetAllOrdersByEmployeeCode/{employeeCode}")]
    public List<Orders> GetAllOrdersByEmployeeCode(int employeeCode)
    {
      return orderService.GetOrdersByEmployeeCode(employeeCode);
    }

    [HttpGet("getOrderPriceByOrderCode/{orderCode}")]
    public decimal GetOrderPriceByOrderCode(int orderCode)
    {
      return orderService.GetOrderPriceByOrderCode(orderCode);
    }
    [HttpPost("addNewOrder")]
    [EnableCors("CorsPolicy")]
    public int AddOrder(Orders newOrder)
    {
      return orderService.AddOrder(newOrder);
    }

    [HttpPost("deleteOrderByOrderCode")]
    [EnableCors("CorsPolicy")]
    public bool DeleteOrderByOrderCode([FromBody] int orderCode)
    {
      return orderService.DeleteOrderByOrderCode(orderCode);
    }

    [HttpPost("updateTotalPaymentForOrder")]
    [EnableCors("CorsPolicy")]
    public void UpdateTableStatus([FromBody] OrderToUpdate data)
    {
      orderService.UpdateTotalPaymentForOrder(data);
    }
    [HttpGet("isOrderPaid/{orderCode}")]
    public bool IsOrderPaid(int orderCode)
    {
      return orderService.IsOrderPaid(orderCode);
    }
    [HttpGet("getTotalIncomeToDay")]
    public decimal GetTotalIncomeToDay()
    {
      return orderService.GetTotalIncomeToDay();
    }
        [HttpGet("pdf/{orderCode}")]
        public FileStreamResult pdf(int orderCode)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            FileStream imageStream = new FileStream("Logo.png", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image,0, 0, 80, 80);
            graphics.DrawString(DateTime.Today.ToString("dd/MM/yyyy") + "  " + DateTime.Now.ToShortTimeString(), font, PdfBrushes.Black, new PointF(400, 0));

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list
            List<OrderDetailsReceipt> data = orderDetailsService.GetOrderDetailsReceiptsByOrderCode(orderCode);

            //Add list to IEnumerable
            IEnumerable<OrderDetailsReceipt> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;

            //Creates the grid cell styles
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;

            cellStyle.TextPen = PdfPens.Black;
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            for (int i = 0; i < pdfGrid.Rows.Count; i++)
            {
                for (int j = 0; j < pdfGrid.Rows[i].Cells.Count; j++)
                {
                    PdfGridCell pdfGridCell = pdfGrid.Rows[i].Cells[j];
                    pdfGridCell.Style = cellStyle;
                }
            }

            PdfGridRow header = pdfGrid.Headers[0];

            //Creates the header style
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(Color.Black);
            headerStyle.BackgroundBrush = new PdfSolidBrush(Color.Black);
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

            //Adds cell customizations
            for (int i = 0; i < header.Cells.Count; i++)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Applies the header style
            header.ApplyStyle(headerStyle);
            cellStyle.Borders.All = new PdfPen(Color.Black, 0.70f);
            // cellStyle.Borders.Bottom = new PdfPen(Color.Goldenrod, 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(Color.White);
            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            // Creates layout format settings to allow the table pagination
            layoutFormat.Layout = PdfLayoutType.Paginate;
            //Draws the grid to the PDF page.
            PdfGridLayoutResult gridResult = pdfGrid.Draw(page, new RectangleF(new PointF(0, 100), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

            //Total price
            PdfFont priceFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            decimal price = orderService.GetOrderPriceByOrderCode(orderCode);
            graphics.DrawString("Total price: " + price, priceFont, PdfBrushes.Black, new PointF(380, data.Count * 16 + 130));
            Employees employee = employeeService.GetEmployeeByOrderCode(orderCode);
            graphics.DrawString("Waiter who handle the order: " + employee.EmployeeFirstName.Trim() + " " + employee.EmployeeLastName.Trim() + "\n", font, PdfBrushes.Black, new PointF(140, data.Count * 10 + 210));
            graphics.DrawString("Thank you for visiting our restaurant.\n\n    We will be happy to serve you again!", font, PdfBrushes.Black, new PointF(160, data.Count * 10 + 230));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Close the document.
            document.Close(true);

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Receipt.pdf";
            return fileStreamResult;
        }
    }
}
