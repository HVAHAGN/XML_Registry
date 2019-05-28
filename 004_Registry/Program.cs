﻿using System;
using Microsoft.Win32;

// Редактирование реестра.

namespace RegistryBasics
{
    class Program
    {
        static void Main()
        {
            // В этот раз открываем специально для записи.
            RegistryKey myKey = Registry.CurrentUser;

            // Второй аргумент (true) говорит о том, что будет совершаться запись.
            RegistryKey wKey = myKey.OpenSubKey("Software", true);	
            
            try
            {
                Console.WriteLine("Всего записей в {0}: {1}.", wKey.Name, wKey.SubKeyCount);

                // пытаемся создать новый ключ.
                RegistryKey newKey = wKey.CreateSubKey("CyberBionicSystematics");
                // Запись прошла успешно в HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node

                Console.WriteLine("Запись \'{0}\' успешно внесена в реестр!", newKey.Name);
                Console.WriteLine("Теперь записей стало: {0}.", wKey.SubKeyCount);
            }
            catch (Exception e)
            {
                // Если возникает проблема - выводим сообщение о ней на экран.
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Закрыть ключ нужно обязательно.
                myKey.Close();
            }	

            // Задержка на экране.
            Console.ReadKey();
        }
    }
}
