using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Lab_sp.Models
{
    /* TODO 1.1b: Доопределение контекста
     * Включаем новые классы в контекст 
     * Класс контекста определён как partial
     * Это позволяет нам дополнять его, не изменяя автосгенерированный код
     * (иначе при перестроении модели можно потрять свои изменения)
     */

    // Раскомментируйте код ниже после создания модели

    public partial class STUD_20Context : DbContext
    {
        /*
        public virtual DbSet<Example12_Res> Example12_Res { get; set; }
        public virtual DbSet<Inline_F01_Res> Inline_F01_Res { get; set; }

         // Используя Fluent API, определяем свойства набора данных
         // В частности указываем, что наборы не имеют ключевого поля
         
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example12_Res>().HasNoKey();
            modelBuilder.Entity<Inline_F01_Res>().HasNoKey();

            // Возвращайтесь к задаче TODO 1.1c
        }
       */         
    }
}

