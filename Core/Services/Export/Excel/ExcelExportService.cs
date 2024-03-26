using ClosedXML.Excel;

namespace GamesAPI.Core.Services;

public class ExcelExportService<TExportDto> : IExcelExportService<TExportDto> {
    // return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
    public virtual FileContents Export(List<TExportDto> exportDtos, string fileName = "export.xlsx") {
        using (XLWorkbook workbook = new XLWorkbook()) {
            IXLWorksheet worksheet = workbook.Worksheets.Add(fileName);

            // header
            System.Reflection.PropertyInfo[] properties = typeof(TExportDto).GetProperties();
            for (int i = 0; i < properties.Length; i++) {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
            }

            // data
            for (int i = 0; i < exportDtos.Count; i++) {
                for (int j = 0; j < properties.Length; j++) {
                    object? valueObj = properties[j].GetValue(exportDtos[i]);
                    
                    if(valueObj is null)
                        continue;

                    string value = valueObj.ToString()!;

                    worksheet.Cell(i + 2, j + 1).Value = value.ToString();
                }
            }

            using (MemoryStream stream = new MemoryStream()) {
                workbook.SaveAs(stream);
                byte[] fileBytes = stream.ToArray();

                return new FileContents(fileName, fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
    }
}