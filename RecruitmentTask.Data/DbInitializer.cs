using RecruitmentTask.Core;
using RecruitmentTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public static class DbInitializer
    {
        public static void Seed(this AppDbContext context)
        {

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product { Name = "2018 Viking Paloma Ladies Traditional Dutch Bike 26\"", Category = Category.Sport, Description = "The ladies version of the Viking Paloma inherits aspects from traditional bikes and mixes them with modern day features creating a ride for all occasions. Weather its a ride to the city or a countryside jaunt with friends, the Paloma has you covered with it's powerful V brakes for confident stopping in all conditions, strong hi-tensile steel frame with a low step over design for quick, easy mounting and dismounting. The Retro style swept-back handlebars and front wicker basket replicate vintage cycling history, combined with silver lightweight alloy rims, twin steel mudguards and wide Kenda tyres for enhanced grip on road and trail surfaces.", Price = 134.95M },
                    new Product { Name = "RDX Leather Boxing Gloves MMA Training Fight Sparring Punching kickboxing F15MB", Category = Category.Sport, Description = "These matte black boxing gloves hold no punches with their exclusive ConvEX Skin Combat Leather casing that’s durable, vegan and non-toxic. The Quadro-Dome™ mould of the gloves ensures that the wearer maintains correct fist form at all times, which helps to reduce chances of needless injury. Moreover, to keep hands safe and secured, the glove is layered with multiple slabs of shock-absorbent EVA-LUTION padding. The gloves also feature nylon mesh palms to aerate hands to keep them dry. An inner anti-microbial lining prevents growth of bacteria and the Quick EZ hook-and-loop ensures secure wear and easy removal.", Price = 27.99M },
                    new Product { Name = "2 x Wilson Fusion XL Tennis Rackets + 3 Balls RRP £100", Category = Category.Sport, Description = "The Wilson Fusion XL is a recreational tennis racket offering a bigger sweet spot and explosive power thanks to V-Matrix technology and an over sized 112in2 (723cm2) head. Best suited to beginners, the racket is head light balanced for easy handling and helps to generate more spin due to an open 16x19 string pattern. Stop Shock Sleeves technology reduces vibrations and enhances control over shots, whereas AirLite Alloy construction delivers lightweight strength.", Price = 39.99M },
                    new Product { Name = "Wilson MVP Traditional Series Heritage Basketball Outdoor Ball", Category = Category.Sport, Description = "Heritage Performance Rubber Basketball. Innovative Rubber Cover for Recreational Outdoor Play. Exceptional Durability. Perfect for Basketball Camps. Wilson Basketball is available in 3 Sizes. Size 5 is suitable for Youth's age 7-11. Size 6 is the Women's Official Size. Size 7 is the Men's Official Size. Basketball is shipped deflated. Always moisten Needle before inflating", Price = 10.95M },
                    new Product { Name = "Hasbro Power Rangers Lightning Collection Wave 1 - MMPR Lord Zedd", Category = Category.Toy, Description = "This 6-inch lightning collection Mighty Morphin Lord Zedd features premium paint and sculpted details inspired by the original series, over 20 points of articulation for high poseability, and includes his staff with a lightning-shaped attachment that makes it look like it’s blasting power, plus a growth bomb accessory that kids can imagine Lord Zedd uses to turn monsters into giant-sized enemies. Go go Power rangers!", Price = 23.99M },
                    new Product { Name = "Kids Toy DOCTOR TROLLEY PLAY SET Childrens Medical Nurse 13 Piece Case on Wheels", Category = Category.Toy, Description = "These compact kits have all your child needs to take their role playing to the next level. The 13 piece set includes loads of different medical items to help them really commit to their Doctor role play. Your enthusiastic Doctors and Nurses will get hours of fun from this great toy set.", Price = 14.97M }
                );

                context.SaveChanges();
            }

        }

    }
}