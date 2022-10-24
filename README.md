# Inventario.Back

Pasos para compilar:
1. Clonar el repositorio en Visual Studio.
2. Colocar la Cadena de conexión según la base de datos en appsettings.json:
![image](https://user-images.githubusercontent.com/58633633/197651170-f212d4fb-cb9c-43f7-9bce-396acb7580ce.png)

3. Ejecutar los Scripts del Repositorio SQL (https://github.com/Jmurga16/Inventario.Scripts) en el siguiente Orden:
- Menu.sql
- Tablas.sql
- PoblacionDatos.sql
- FuncionSplit.sql
- Los demás archivos SQL (Procedures)
4. Compilar y ejecutar la solución desde el Visual Studio (F5).

Modelo de Base de Datos:

![image](https://user-images.githubusercontent.com/58633633/196407046-c4ced145-3160-439e-8b7d-01b8c87641f3.png)

Arquitectura Usada (Clean Code):

![image](https://user-images.githubusercontent.com/58633633/196407286-e2bb0849-753c-41e8-bf3b-4f7615181395.png)
