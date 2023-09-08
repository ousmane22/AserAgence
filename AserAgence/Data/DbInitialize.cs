using AserAgence.Models;
using Microsoft.EntityFrameworkCore;

namespace AserAgence.Data
{
    public static class DbInitialize
    {
        public static void Initialize(AserAgenceDbContext dbContext)
        {
            SeedData(dbContext);
        }

        private static void SeedData(AserAgenceDbContext dbContext)
        {
            if (!dbContext.Region.Any())
            {
                dbContext.Region.AddRange(
                    new Region { RegionName = "Dakar" },
                    new Region { RegionName = "Diourbel" },
                    new Region { RegionName = "Fatick" },
                    new Region { RegionName = "Kaffrine" },
                    new Region { RegionName = "Kaolack" },
                    new Region { RegionName = "Kédougou" },
                    new Region { RegionName = "Kolda" },
                    new Region { RegionName = "Louga" },
                    new Region { RegionName = "Matam" },
                    new Region { RegionName = "Saint-Louis" },
                    new Region { RegionName = "Sédhiou" },
                    new Region { RegionName = "Tambacounda" },
                    new Region { RegionName = "Thiès" },
                    new Region { RegionName = "Ziguinchor" }
                );
                dbContext.SaveChanges();
            }

            dbContext.Department.AddRange(
                // Région de Dakar
                new Department { DepartmentName = "Dakar" },
                new Department { DepartmentName = "Guédiawaye" },
                new Department { DepartmentName = "Pikine" },
                new Department { DepartmentName = "Rufisque" },

                // Région de Diourbel
                new Department { DepartmentName = "Bambey" },
                new Department { DepartmentName = "Diourbel" },
                new Department { DepartmentName = "Mbacké" },

                // Région de Fatick
                new Department { DepartmentName = "Fatick" },
                new Department { DepartmentName = "Gossas" },
                new Department { DepartmentName = "Foundiougne" },

                // Région de Kaffrine
                new Department { DepartmentName = "Kaffrine" },
                new Department { DepartmentName = "Koungheul" },

                // Région de Kaolack
                new Department { DepartmentName = "Kaolack" },
                new Department { DepartmentName = "Guinguinéo" },
                new Department { DepartmentName = "Nioro du Rip" },

                // Région de Kédougou
                new Department { DepartmentName = "Kédougou" },
                new Department { DepartmentName = "Saraya" },

                // Région de Kolda
                new Department { DepartmentName = "Kolda" },
                new Department { DepartmentName = "Médina Yoro Foulah" },
                new Department { DepartmentName = "Vélingara" },

                // Région de Louga
                new Department { DepartmentName = "Kébémer" },
                new Department { DepartmentName = "Linguère" },
                new Department { DepartmentName = "Louga" },

                // Région de Matam
                new Department { DepartmentName = "Matam" },
                new Department { DepartmentName = "Ranérou Ferlo" },

                // Région de Saint-Louis
                new Department { DepartmentName = "Dagana" },
                new Department { DepartmentName = "Podor" },
                new Department { DepartmentName = "Saint-Louis" },

                // Région de Sédhiou
                new Department { DepartmentName = "Bounkiling" },
                new Department { DepartmentName = "Goudomp" },
                new Department { DepartmentName = "Sédhiou" },

                // Région de Tambacounda
                new Department { DepartmentName = "Bakel" },
                new Department { DepartmentName = "Goudiry" },
                new Department { DepartmentName = "Tambacounda" },

                // Région de Thiès
                new Department { DepartmentName = "M'bour" },
                new Department { DepartmentName = "Thiès" },
                new Department { DepartmentName = "Tivaouane" },

                // Région de Ziguinchor
                new Department { DepartmentName = "Bignona" },
                new Department { DepartmentName = "Oussouye" },
                new Department { DepartmentName = "Ziguinchor" }
            );

            dbContext.SaveChanges();


            dbContext.Commune.AddRange(
                new Commune { CommuneName = "Dakar" },
                new Commune { CommuneName = "Guédiawaye" },
                new Commune { CommuneName = "Pikine" },
                new Commune { CommuneName = "Rufisque" },
                new Commune { CommuneName = "Bambey" },
                new Commune { CommuneName = "Diourbel" },
                new Commune { CommuneName = "Mbacké" },
                new Commune { CommuneName = "Fatick" },
                new Commune { CommuneName = "Foundiougne Passy" },
                new Commune { CommuneName = "Sokone Soum Karang Post" },
                new Commune { CommuneName = "Gossas" },
                new Commune { CommuneName = "Kaffrine Nganda" },
                new Commune { CommuneName = "Koungheul" },
                new Commune { CommuneName = "Malem Hoddar" },
                new Commune { CommuneName = "Guinguinéo" },
                new Commune { CommuneName = "Kaolack Kahone Ndoffane Gandiaye" },
                new Commune { CommuneName = "Nioro Keur Madiabel" },
                new Commune { CommuneName = "Kédougou" },
                new Commune { CommuneName = "Salémata" },
                new Commune { CommuneName = "Saraya" },
                new Commune { CommuneName = "Kolda Dabo Salikégné Saré YobaDiéga " },
                new Commune { CommuneName = "Médina Yoro Foulah Pata" },
                new Commune { CommuneName = "Vélingara Kounkané Diaobé-Kabendou" },
                new Commune { CommuneName = "Kébémer Guéoul" },
                new Commune { CommuneName = "BARKEDJI" },
                new Commune { CommuneName = "Linguère Dahra" },
                new Commune { CommuneName = "Louga" },
                new Commune { CommuneName = "Kanel Ouaoundé Semmé Dembancané" },
                new Commune { CommuneName = "Hamady Hounaré Sinthiou Bamambé-Banadji" },
                new Commune { CommuneName = "Matam Ourossogui Thilogne" },
                new Commune { CommuneName = "Matam Ourossogui Thilogne" },
                new Commune { CommuneName = "Ranérou" },
                new Commune { CommuneName = "Dagana Richard Toll Rosso Diama Gaé" },
                new Commune { CommuneName = "Ross-Béthio " },
                new Commune { CommuneName = "Podor Golléré Ndioum Niandane Mbouma" },
                new Commune { CommuneName = "Guédé Chantier Démette Galoya Toucouleur" },
                new Commune { CommuneName = "Saint Louis Mpal" },
                new Commune { CommuneName = "Bounkiling Madina Wandifa" },
                new Commune { CommuneName = "Goudomp Samine Tanaff Diattacounda" },
                new Commune { CommuneName = "Sédhiou Diannah Malary Marsassoum" },
                new Commune { CommuneName = "Bakel Kidira Diawara" },
                new Commune { CommuneName = "Goudiry Kothiary" },
                new Commune { CommuneName = "Koumpentoum" },
                new Commune { CommuneName = "Tambacounda" },
                new Commune { CommuneName = "Joal – Fadhiouth Diass Nguekhokh Thiadiaye Saly Portudal Ngaparou Somone Popenguine" },
                new Commune { CommuneName = "Thies Kayar Khombole Pout" },
                new Commune { CommuneName = "Tivaouane Mboro Mékhé" },
                new Commune { CommuneName = "Ziguinchor" },
                new Commune { CommuneName = "Oussouye" },
                new Commune { CommuneName = "Bignona Thionck-Essyl Diouloulou" }
            );

            dbContext.SaveChanges();

        }
    }
}
