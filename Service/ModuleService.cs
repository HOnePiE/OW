using astn_course.Model;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using astn_course.Pages.Admin;

namespace astn_course.Service
{
	public class ModuleService
	{
		public static List<StaticModel> ListGender()
		{
			List<StaticModel> list = new()
			{
				new StaticModel
				{
					id = 1,
					name = "Male",
				},
				new StaticModel
				{
					id = 2,
					name = "Female",
				},
				new StaticModel
				{
					id = 3,
					name = "Other",
				},
			};
			return list;
		}

		public static List<StaticModel> ListLevel() 
		{
			List<StaticModel> list = new()
			{
				new StaticModel
				{
					id = 1,
					name = "Beginners",
				},
				new StaticModel
				{
					id = 2,
					name = "Advance",
				},
				new StaticModel
				{
					id = 3,
					name = "Intermediate",
				},
			};
			return list;
		}

		public static async Task<List<AuthModel>> GetModelsAsync(string filePath)
		{
			var models = new List<AuthModel>();

			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
			{
				// Đọc các dòng từ file CSV
				await foreach (var record in csv.GetRecordsAsync<AuthModel>())
				{
					models.Add(record);
				}
			}
			return models;
		}
	}
}
