using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Windows.Forms;

namespace Lab_sp
{
    class DataAccess
    {
        /* TODO 0 : Цели и задачи
         * Задача лабораторной - изучение средств технологии Entity Framework Core 
         * для работы с SQL-запросами, в т.ч. 
         * для использования функционала БД (хранимых процедур и пользовательских функций).
         * Документация:
         * https://docs.microsoft.com/ru-ru/ef/core/querying/raw-sql#limitations
         */

        /* TODO 0.1: Подготовка к работе
         * Должны быть установлены NuGet пакеты:
         * - Microsoft.EntityFrameworkCore.SqlServer,
         * - Microsoft.EntityFrameworkCore.Tools.
         * Это можно сделать через менеджер пакетов (Project \ Manage NuGet Packages ...).
         * 
         * Или через консоль диспетчер пакетов (Tools \ NuGet Package Manager \ Package Manager Console), 
         * выполнив команды:
         * Install-Package Microsoft.EntityFrameworkCore.SqlServer
         * Install-Package Microsoft.EntityFrameworkCore.Tools
         */

        /* TODO 0.2: Создание модели данных
         * Необходимо создать модель сущностых классов, используя подход DataBase First,
         * т.е. сгенерировать модель на основе существующей БД.
         * Для этого в окне диспетчера пакетов (Package Manager Console) выполните команду,
         * указав в ней путь к БД STUD_20:
         * 
         * Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Lena\NET\DB\STUD_20.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -Context STUD_20Context -OutputDir Models -Tables STUDENTS, GROUPS, SUBJECTS, TUTORS, CHAIRS, CURRICULUM, Test_Table
         * 
         * Команда не отработает, если есть ошибки компиляции
         * Поэтому код, зависящий от модели, пока закомментирован
         * 
         * Документация:
         * https://docs.microsoft.com/ru-ru/ef/core/managing-schemas/scaffolding?tabs=vs
         */


        public Form1 form1;

        /* 
         * Контекст данных
         * Классы модели данных находятся в папке Models
         */

        Models.STUD_20Context context = new Models.STUD_20Context();

        /* TODO 1.1: Примеры выполнения SQL-запросов
         * Все примеры работоспособны, можете раскомментировать и выполнять их по очереди
         */

        public void Task11(string param1, string param2)
        {
            /* Пример 1.0
             * Простой запрос с возвратом объектов сущностного класса Students
             * Раскомментируйте строку ниже, запустите программу и нажмите на форме первую кнопку "Вызвать!"
             */
            //form1.dataGridView11.DataSource = context.Students.FromSqlRaw("SELECT * FROM STUDENTS").ToList();

            /* Пример 1.1
             * Запрос с возвратом не-сущностных объектов
             * Прежде чем выполнять запрос, найдите в списке задач (View \ Task List)
             * задачи TODO 1.1a и 1.1b (они в других файлах)
             */
            /* TODO 1.1c: После выполнения задач TODO 1.1a и 1.1b, раскомментируйте строку кода ниже
             */
            //form1.dataGridView11.DataSource = context.Example12_Res.FromSqlRaw("SELECT Name, Surname FROM STUDENTS").ToList();

            /* Пример 1.2
             * Вызов функции Inline_F01
             * Откройте эту функцию в БД или в обозревателе серверов
             * Для этого раскройте БД STUD_20 и найдите в ней Functions или Programmability \ Functions
             * Изучите входные параметры и структуру выходного набора
             * Для возврата данных создан класс Lab_sp.Models.Inline_F01_Res, 
             * по аналогии с тем, как это сделано в предыдущем примере
             * Значения param1 и param1 устаналиваются на форме Form1
             */

            // Передача параметров путём форматирования строки
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw("SELECT * FROM dbo.Inline_Function_N01 ({0}, {1})", param1, param2).ToList();

            // Передача параметров через интерполированную строку $""
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({param1}, {param2})").ToList();

            /* Пример 1.3
             * Создание параметризованного запроса для вызова функции
             * Параметры @group и @absences тспользуются для передачи значений param1 и param1 
             * Обратите внимание на преобразование типа параметра param2
             */
            
            var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
            var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));
            // интерполяция
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({par_group}, {par_absences})").ToList();
            // или форматирование
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw($"SELECT * FROM dbo.Inline_Function_N01 (@group, @absences)", par_group, par_absences).ToList();
            

            /* Больше примеров:
             * https://www.learnentityframeworkcore.com/raw-sql
             */
        }

        /* TODO 1.2
         * Вызов пользовательской функции в соответсвии с вариантом задания.
         * Изучите функцию в соответсвии с вашим вариантом задания.
         * Для этого необходимо открыть БД, например, используя программу 
         * MS SQL Server Management Studio или Visual Studio.
         * В окне Server Explorer или SQL Server Object Explorer развернуть узел дерева
         * STUD_20\Programmability\Functions\
         * или (зависит от того, какой программой пользуетесь)
         * Databases\STUD_20\Programmability\Functions\Table-valued Functions
         * Найти нужную функцию и изучть её исходный код
         * Опишите, какие параметры принимает данная функция и какие результаты
         * она возвращает:
         * _______________________________________________________________________________________________
         * _______________________________________________________________________________________________
         * _______________________________________________________________________________________________
         * 
         * В методе Task12() запрограммируйте вызов этой функции
         * и привязку возвращённых ею данных к компоненту form1.dataGridView11
         * Не забудьте создать класс для возврата результатов и включить его в контекст (см. примеры 1.1, 1.2)
         * Если второй параметр не нужен - забейте на него
         */
        public void Task12(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null;
        }

        /* TODO 1.3
         * Создание и вызов собственной пользовательской функции
         * В БД создайте собственную пользовательскую функцию на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * Дополнительные сведения и примеры функций Transact-SQL см. в библиотеке MSDN:
         * https://msdn.microsoft.com/ru-ru/library/ms186755.aspx
         * 
         * Для создания функции найдите список функций БД (см. предыдущую задачу), щёлкните правой кнопкой на списке Functions
         * и выберите команду Add new \ Inline Function
         * В открывшемся окне отредактируйте код SQL-запроса CREATE FUNCTION
         * 
         * В методе Task13() запрограммируйте вызов этой функции
         * и привязку возвращённых ею данных к компоненту form1.dataGridView11
         */
        public void Task13(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null;
        }

        /* TODO 1.4
         * Создание и вызов собственной табличной пользовательской функции
         * В БД создайте собственную пользовательскую функцию на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * В отличие от предыдущего задания, здесь придётся описывать структуру выходной таблицы
         * В качестве примера можно посмотреть в БД функцию Table_Function_N0100
         * В методе Task13() запрограммируйте вызов этой функции
         * и привязку возвращённых ею данных к компоненту form1.dataGridView11
         */
        public void Task14(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null;
        }


        /* TODO 2.1
         * Пример вызова хранимой процедуры StoredProc_N0100
         * 
         * Обратите внимание, что в отличие от функций, процедурам параметры передаются без скобок
         * Кроме того обратите внимание на получение выходного параметра,
         * а также обработку исключений
         * 
         * Для просмотра результатов на форме перейдите на вкладку Вызов хранимых процедур 
         * и нажмите первую кнопку Вызвать!
         */

        public int OutValue21 = -1;

        public void Task21(string param1, string param2, string param3)
        {
            try
            {

                var par_output = new Microsoft.Data.SqlClient.SqlParameter("@outparam", System.Data.SqlDbType.Int);
                par_output.Direction = System.Data.ParameterDirection.Output;

                // интерполяция строк
                context.Database.ExecuteSqlInterpolated($"EXEC StoredProc_N0100 {param1}, {param2}, {param3}, {par_output} OUT");

                // то же самое через форматирование
                //context.Database.ExecuteSqlRaw("EXEC StoredProc_N0100 {0}, {1}, {2}, @outparam OUT", param1, param2, param3, par_output);

                // обновление данных на форме
                // раскомментируйте строку ниже

                //form1.Test_dataGridView.DataSource = context.TestTable.ToList();
                OutValue21 = (int)par_output.Value;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+"\n\n"+ (e.InnerException != null ? e.InnerException.Message : ""));
            }
        }

        /* TODO 2.2
         * Создание хранимой процедуры в соответсвии с вариантом задания.
         * В БД создайте собственную хранимую процедуру на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * Дополнительные сведения и примеры создания хранимых процедур Transact-SQL 
         * см. в библиотеке MSDN:
         * https://msdn.microsoft.com/ru-ru/library/ms187926.aspx
         * 
         * В методе Task22() запрограммируйте вызов этой хранимой процедуры
         * и обновление данных из таблицы Test_Table в компоненте form1.Test_dataGridView
         * Не забудьте получить выходной параметр
         * Значение выходного параметра поместите в переменную OutValue22
         */

        public int OutValue22 = -1;

        public void Task22(string param1, string param2)
        {
            form1.Test_dataGridView.DataSource = null;
        }

        /* TODO 2.3
         * Создание и вызов собственной хранимой процедуры
         * Создайте в БД хранимую процедуру в соответсвии с вашим вариантом задания
         * В методе Task23() запрограммируйте вызов этой хранимой процедуры
         * и обновление данных из таблицы Test_Table в компоненте form1.Test_dataGridView
         * Реализуйте обработку исключений
         */

        public void Task23(string param1, string param2)
        {
            form1.Test_dataGridView.DataSource = null;
        }

    }
}
