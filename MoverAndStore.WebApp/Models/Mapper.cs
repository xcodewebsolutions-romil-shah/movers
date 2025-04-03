using System.Xml.Linq;
using static MoverAndStore.WebApp.Controllers.HomeController;

namespace MoverAndStore.WebApp.Models
{
    public class Mapper
    {
        public static DealData Map(SaveDataModel source)
        {
            DateTime? dateTimeValue = DateTime.Now; // Your nullable DateTime value

            DateOnly? dateOnlyValue = dateTimeValue.HasValue
                ? DateOnly.FromDateTime(dateTimeValue.Value)
                : (DateOnly?)null;

            return new DealData
            {
                Basic_Information = new BasicInformation
                {
                    id = source.PID,
                    Title = source.Title,
                    Moving_Date = Convert.ToDateTime(source.Moving_Date),
                    Lead = new Lead
                    {
                        Contact_Person = source.Contact_Person,
                    },
                    AddressGroup = new AddressGroup
                    {
                        Address_1 = source.Address_1,
                        Address_3 = source.Address_3,
                        Address_2 = source.Address_2,
                        Living_1_Levels = source.Living_1_Levels,
                        Living_2_Levels = source.Living_2_Levels,
                        Living_3_Levels = source.Living_3_Levels,
                        Living_2_Layers = source.Living_2_Layers,
                        Living_1_Layers = source.Living_1_Layers,
                        Living_3_Layers = source.Living_3_Layers,
                        //Lift_1_Bool = source.lift_1_bool,
                        Lift_2_Bool = source.Lift_2_Bool,
                        Lift_3_Bool = source.Lift_3_Bool,
                        Type_1_Living = source.Type_1_Living,
                        Type_2_Living = source.Type_2_Living,
                        Type_3_Living = source.Type_3_Living,
                        Lift_1_Distance_Door = source.lift_1_distance_door,
                        Lift_2_Distance_Door = source.Lift_2_Distance_Door,
                        Lift_3_Distance_Door = source.Lift_3_Distance_Door,
                        Parking_1_bool = source.Parking_1_bool,
                        Parking_2_bool = source.Parking_2_bool,
                        Parking_3_bool = source.Parking_3_bool,

                    },

                    Activitiesgroup = new Activitiesgroup
                    {
                        Furniture_Assembly_Bool = source.Furniture_Assembly_Bool,
                        Items_To_Assemble = source.Items_To_Assemble,
                    },

                    PreferedDatesGroup = new PreferedDatesGroup
                    {
                        option1 = Convert.ToDateTime(source.option1),
                        option2 = Convert.ToDateTime(source.option2),
                        option3 = Convert.ToDateTime(source.option3),
                    },
                    Extra_Info_Group = new Extra_info_group
                    {
                        start_time = source.start_time,
                        end_time = source.end_time,
                        estimated_movers = source.estimated_movers,
                        estimated_movers_update = source.estimated_movers_update,   
                        extra_info = source.extra_info,
                        type_moving_wagen = source.type_moving_wagen,
                    },
                    MaterialGroup = new MaterialGroup
                    {
                        boxes = source.boxes,
                        boxes_update = source.boxes_update,
                        wardrobe_boxes_update = source.wardrobe_boxes_update,
                        wardrobe_boxes = source.wardrobe_boxes,
                        folie = source.folieboxes,
                        folie_update = source.folie_update,
                    },

                    ContentGroup = new ContentGroup
                    {
                        Content_1 = source.Content_1,
                        Content_2 = source.Content_2,
                    }

                },
                Crminfo = new CrmInfo
                {
                    //Source = source.Source,
                    //Currency = source.Currency,
                    //Success_percentage = source.Success_percentage,
                    //Pipeline = source.Pipeline,
                    //Responsible = source.Responsible,
                }
                //Notes = new Notes
                //{
                //    foreman_notes = source.foreman_notes,
                //},
                //user_dashboard = new Userashboard
                //{
                //    Foremanname = source.Foreman_name
                //},
                //Products = source.Products?.Select(sourceProduct => new Product
                //{
                //    id = sourceProduct.id,
                //    name = sourceProduct.name,
                //    quantity = sourceProduct.quantity,
                //    quantity_update = sourceProduct.quantity_update,
                //}).ToList() ?? new List<Product>()
            };
        }

    }
}
