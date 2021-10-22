using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemAPI
{
    
    class Program
    {
        static int health = 100;
        static int lives = 3;
        static int shield = 50;        
        static string healthStatus;
        static void Main(string[] args)
        {
            ShowHud();
            TakeDamage(75);
            ShowHud();
            TakeDamage(50);
            ShowHud();
            HealthRegen(50);
            ShowHud();
            ShieldRegen(50);
            ShowHud();
            addLife();
            ShowHud();
            TakeDamage(200);
            ShowHud();
            die();
            ShowHud();
            die();
            ShowHud();
            
            


            Console.ReadKey(true);
        }

        static void ShowHud()
        {

            healthStatus = updateHealthStatus(health);

            Console.WriteLine("====================");
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("Health Status: " + healthStatus);   
            Console.WriteLine("====================");
            
            
        }
        
        static void ShieldRegen(int sp)
        {
            if (sp < 0)
            {
                Console.WriteLine("SP cannot be negative value");
            }
            else
            {
                shield = shield + sp;
                if (shield >= 50)
                {
                    shield = 50;
                }
                Console.WriteLine("Player has picked up " + sp + " shield points!");
            }
        }

        static void HealthRegen(int hp)
        {
            if (hp < 0)
            {
                Console.WriteLine("HP cannot be negative value");
            }
            else
            {
                health = health + hp;
                if (health >= 100)
                {
                    health = 100;
                }
                Console.WriteLine("Player has picked up " + hp + " Health points!");
            }
        }

        static void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("Damage cannot be negative value");
            }
            else
            {
                int remainingDamage;
                remainingDamage = damage - shield;
                shield = shield - damage;
                Console.WriteLine("Player is about to take " + damage + " damage");

                if (shield <= 0)
                {
                    shield = 0;
                    health = health - remainingDamage;
                }

                if (health <= 0)
                {
                    health = 0;
                    die();
                }     
            }
        }

        static void addLife()
        {
            lives = lives + 1;
            Console.WriteLine("Player gained life");
            if (lives >= 3)
            {
                lives = 3;
            } 
                
        }

        static void die()
        {
            lives = lives - 1;
            Console.WriteLine("Player Died");
            if (lives > 0)
            {
                HealthRegen(100);
                ShieldRegen(100);
            }
            else
            {
                health = 0;
                shield = 0;
            }
            if (lives <= 0)
            {
                lives = 0;
            }
           

        }

        static string updateHealthStatus(int currentHealth)
        {
            if (currentHealth <= 100 && currentHealth >= 76)
            {
                return "Healthy";

            }
            if (currentHealth <= 75 && currentHealth >= 51)
            {
                return "Hurt";
            }
            if (currentHealth <= 50 && currentHealth >= 26)
            {
                return "Badly Hurt";
            }
            if (currentHealth <= 25 && currentHealth >= 1)
            {
                return "Dying";
            }
            if (currentHealth <= 0)
            {
                return "Dead";
            }
            else return null; 
        }
        
            
    }
    
}
