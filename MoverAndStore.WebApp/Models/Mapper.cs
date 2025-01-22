using System.Xml.Linq;
using static MoverAndStore.WebApp.Controllers.HomeController;

namespace MoverAndStore.WebApp.Models
{
    public class Mapper
    {
        public static CardData Map(SaveDataModel source)
        {
            DateTime? dateTimeValue = DateTime.Now; // Your nullable DateTime value

            DateOnly? dateOnlyValue = dateTimeValue.HasValue
                ? DateOnly.FromDateTime(dateTimeValue.Value)
                : (DateOnly?)null;

            return new CardData
            {
                Basic_Information = new BasicInformation
                {
                    id = source.PID,
                    Title = source.Title,
                    Status = source.Status,
                    Summary = source.Summary,
                    Company = source.Company,
                    Reference = source.Reference,
                    Lead = new Lead
                    {
                        Contact_Person = source.Contact_Person,
                        Customer = source.Customer,
                        Contact_Person_Telephone = source.Contact_Person_Telephone


                    },
                    AddressGroup = new AddressGroup
                    {
                        address_a = source.Address_A,
                        address_b = source.Address_B,
                        address_c = source.Address_C,
                        pv_1_bool = source.pv_1_bool,
                        pv_2_bool = source.pv_2_bool,
                        pv_3_bool = source.pv_3_bool,
                    }

                },
                Moving_Date = new MovingDate
                {
                    moving_from_date = Convert.ToDateTime(source.moving_from_date),
                    moving_to_date = Convert.ToDateTime(source.moving_to_date),
                    client_arrival_time_update = Convert.ToDateTime(source.Client_Arrival_Time_update)
                },
                Additional_Info = new AdditionalInfo
                {
                    Extra_Info_Lift = source.Extra_Info_Lift,
                    Lift_Location_Enum = source.Lift_Location_Enum,
                    Lift_bool = source.Lift_bool,
                    Lift_Type_Enum = source.Lift_Type_Enum,
                    Items_To_Dismantle = source.Items_To_Dismantle,
                    Items_To_Dismantle_Update = source.Items_To_Dismantle_Update,
                    Number_Of_Movers = source.Number_Of_Movers.ToString(),
                    Number_Of_Movers_Update = source.Number_Of_Movers_Update.ToString(),
                    Time_Estimate = source.Time_Estimate,
                    Time_Estimate_Update = source.Time_Estimate_Update.ToString(),
                    Dismantling_Bool = source.Dismantling_Bool,
                    Dismantling_Bool_Update = source.Dismantling_Bool_Update,
                    Additional_General_Info = source.Additional_General_Info,
                    Hour_start_update = source.Hour_start_update,
                    Hour_stop_update = source.Hour_stop_update,
                    Additional_General_Info_update = source.Additional_General_Info_update,
                    Voertuig_Enum = source.Voertuig_Enum,
                    Voertuig_Type_Enum = source.Voertuig_Type_Enum


                },
                stockage = new Stockage
                {
                    Date_In = Convert.ToDateTime(source.Date_In),
                    Date_Out = Convert.ToDateTime(source.Date_Out),
                    Date_In_Update = source.Date_In_Update.ToString(),
                    Date_Out_Update = source.Date_Out_Update.ToString(),
                    Cubic_Meters = source.Cubic_Meters.ToString(),
                    Cubic_Meters_Update = source.Cubic_Meters_Update.ToString(),
                    Exact_Location = source.Exact_Location,
                    Exact_Location_Update = source.Exact_Location_Update,
                    Options_Enum = source.Options_Enum,
                    Storage = source.Storage,
                    Storage_Update = source.Storage_Update,
                    Insured_Value = source.Insured_Value,
                    Zone = source.Zone,
                    Zone_Update = source.Zone_Update,


                },
                Notes = new Notes
                {
                    foreman_notes = source.foreman_notes,
                },
                user_dashboard = new Userashboard
                {
                    Foremanname = source.Foreman_name
                },
                Products = source.Products?.Select(sourceProduct => new Product
                {
                    id = sourceProduct.id,
                    name = sourceProduct.name,
                    quantity = sourceProduct.quantity,
                    quantity_update = sourceProduct.quantity_update,
                }).ToList() ?? new List<Product>()






        };
        }

    }
}
