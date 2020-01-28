### События и делегаты
---
Используя стандартные события C# сделайте вывод логов вашей программы в файл.

В исходный код класса добавьте описание событий:

    class SaveManager
    {
      public event EventHandler<string> ObjectSaved;
      protected virtual void OnObjectSaved(string message)
      {
          EventHandler handler = ThresholdReached;
          handler?.Invoke(this, message);
      }
      /* ... */
    }
 
При записи данных нужно вызывать обработку сообщения:

    class SaveManager
    {
      /* ... */
      public void WriteObject(IWritableObject obj)
      {
          obj.Write(this);
          OnObjectSaved($"Данные успешно сохранены: {obj.ToString()}");
          
      }
      /* ... */
    }

В основной программе необходимо назначить обработчики событий:

    class Program
    {
      static void Main(string[] args)
      {
        Student s = new Student("Testov T.T.", "TEST-00");
        //
        SaveManager saver = new SaveManager("test.txt");
        
        saver.ObjectSaved += Print;
        
        saver.WriteObject(s);
        /* ... */
      }
      static void Print(string message)
      {
        Console.WriteLine(message);
      }
    }
