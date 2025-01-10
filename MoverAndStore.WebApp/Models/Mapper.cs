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
                },
                Additional_Info = new AdditionalInfo
                {
                    Extra_Info_Lift = source.Extra_Info_Lift,
                    Lift_Location_Enum = source.Lift_Location_Enum,
                    Lift_bool  = source.Lift_bool,
                    Lift_Type_Enum = source.Lift_Type_Enum,
                    //Items_To_Dismantle = source.Items_To_Dismantle,
                    //Items_To_Dismantle_Update = source.Items_To_Dismantle_Update,
                    Number_Of_Movers = source.Number_Of_Movers,
                    Number_Of_Movers_Update = source.Number_Of_Movers_Update,
                }
                

               
            };
        }

    }
}
