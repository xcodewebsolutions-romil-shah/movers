using System.Xml.Linq;
using static MoverAndStore.WebApp.Controllers.HomeController;

namespace MoverAndStore.WebApp.Models
{
    public class Mapper
    {
        public static CardData Map(SaveDataModel source)
        {
            return new CardData
            {
                Basic_Information = new BasicInformation 
                {
                    Title = source.Title,
                    Status = source.Status,
                    Summary = source.Summary,
                    Company = source.Company,
                    Reference = source.Reference,
                    Lead = new Lead 
                    {
                        Contact_Person = source.Contact_Person,
                        Customer = source.Customer,
                        

                    },
                    AddressGroup = new AddressGroup 
                    {
                        address_a = source.Address_A,
                        address_b = source.Address_B,
                        address_c = source.Address_C,
                        pv_1_bool = source.Pv1Bool,
                        pv_2_bool = source.Pv2Bool,
                        pv_3_bool = source.Pv3Bool,
                    }
                    
                },
                Moving_Date = new MovingDate
                {
                    moving_from_date = Convert.ToDateTime(source.moving_from_date),
                    moving_to_date = Convert.ToDateTime(source.moving_to_date),
                    client_arrival_time_update = Convert.ToDateTime(source.client_arrival_time_update)
                },
                Additional_Info = new AdditionalInfo
                {
                    Extra_Info_Lift = source.Extra_Info_Lift,
                    Lift_Location_Enum = source.Lift_Location_Enum,
                    Lift_bool  = source.Lift_bool,
                    Lift_Type_Enum = source.Lift_Type_Enum,
                    Items_To_Dismantle = source.Items_To_Dismantle,
                    Items_To_Dismantle_Update = source.Items_To_Dismantle_Update,
                    Number_Of_Movers = source.Number_Of_Movers,
                    Number_Of_Movers_Update = source.Number_Of_Movers_Update,
                    Time_Estimate = source.Time_Estimate,
                    Time_Estimate_Update = source.Time_Estimate_Update,
                    Dismantling_Bool = source.Dismantling_Bool,
                    Dismantling_Bool_Update = source.Dismantling_Bool_Update,
                    Additional_General_Info = source.Additional_General_Info,
                    Hour_start_update = Convert.ToDateTime(source.Hour_start_update),
                    Hour_stop_update = Convert.ToDateTime(source.Hour_stop_update),
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
                    Cubic_Meters = source.Cubic_Meters,
                    Cubic_Meters_Update = source.Cubic_Meters_Update,
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
                Products = new List<Product>
                {
                    new Product
                    {
                        id = source.id,
                        name = source.name,
                        quantity = source.quantity,
                        quantity_update = source.quantity_update,
                    }
                }

                
               

                
            };
        }

    }
}
