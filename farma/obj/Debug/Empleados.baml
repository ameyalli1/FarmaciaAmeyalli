   M S B A M L   `   `   `  ����@  <farma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:farmafarma  5   	       farma.Empleados   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:farma     5   	     � Title$  	productos��5   	   $	��332��6   $	��559��6(   ��5	      �� 5
   
    �� ImageSource$ Imagenes/images.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��25(�6   $��Center=�6   $��0��6;   .��6H   Registro de Empleados6_   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Identificador *6V   �� 5      -   5         ��Name$ txbIde��5      $	��180��6*   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   
Nombre *6O   �� 5      -   5        $ 
txbNombree��5      $	��180��6.   6<   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Direccion *6R   �� 5       -   5        $ txbDireccion��5       $	��180��60   6>   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   RFC*6K   �� 5$      -   5        $ txbRfc��5$      $	��180��6*   68   5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   	Telefono*6P   �� 5(      -   5        $ txbTelefono��5(      $	��180��6/   6=   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   	Correo*6N   �� 5,      -   5        $ 	txbCorreo��5,      $	��180��6-   6;   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   	Sueldo*6N   �� 50      -   5        $ 	txbSueldo��50      $	��180��6-   6;   51      �� 52      $��16(�6   $��Arial)�6"   $��Italic$�65   .��6H   * Campos obligatorios6_   53      � 54   
   $��2��6   .+�55      �� -   5         ��Name$ 	btnNuevoo��55       $��80��6   .��56      �� $ 
Horizontal=�6   .+�57      �� .��6   Nuevo6#   �� 58      $��16��6   $��/Imagenes/add.png��6'   6E   59      5:      �� 5;      -	   5        $ btnGuardarr��5;       $��80��6   .��5<      �� $ 
Horizontal=�6   .+�5=      �� .��6   	Guardar6%   �� 5>      $��16��6   $��/Imagenes/page_save.png��6'   6K   5?      5@      �� 5A      -
   5        $ 
btnEditarr��5A       $��80��6   .��5B      �� $ 
Horizontal=�6   .+�5C      �� .��6   Editar6$   �� 5D      $��16��6   $��/Imagenes/table_edit.png��6'   6L   5E      5F      �� 5G      -   5        $ btnCancelarr��5G       $��80��6   .��5H      �� $ 
Horizontal=�6   .+�5I      �� .��6   
Cancelar6&   �� 5J      $��16��6   $��/Imagenes/Cancel.png��6'   6H   5K      5L      �� 5M      -   5        $ btnEliminarr��5M       $��80��6   .��5N      �� $ 
Horizontal=�6   .+�5O      �� .��6   
Eliminar6&   �� 5P      $��16��6   $$��/Imagenes/table_row_delete.png��6'   6R   5Q      5R      �� 5S      -   5        $ btnRegresar��5S       $��80��6   .��5T      �� $ 
Horizontal=�6   .+�5U      �� .��6   
Regresar6&   �� 5V      $��16��6   $#��/Imagenes/arrow_turn_left.png��6'   6Q   5W      5X      5Y      &   System.Windows.Controls.DataGrid  5Z   
   -   5          Name$ dtgTabla��5Z         
IsReadOnly . $��3��67   5\      5]      