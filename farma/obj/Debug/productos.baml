   M S B A M L   `   `   `  ����@  <farma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:farmafarma  5   	       farma.productos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:farma     5   	     � Title$  	productos��5   	   $	��332��6   $	��559��6(   ��5	      �� 5
   
    �� ImageSource$ Imagenes/images.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��25(�6   $��Center=�6   $��0��6;   .��6H   Registro de productos6_   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Identificador *6V   �� 5      -   5         ��Name$ txbIde��5      $	��180��6*   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   
Nombre *6O   �� 5      -   5        $ 
txbNombree��5      $	��180��6.   6<   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Descripcion *6T   �� 5       -   5        $ txbDescripcionn��5       $	��180��63   6A   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Precio de venta*6W   �� 5$      -   5        $ txbPrecioventaa��5$      $	��180��63   6A   5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Precio de compra*6X   �� 5(      -   5        $ txbPrecioCompraa��5(      $	��180��64   6B   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $	��140��6   $��Arial)�6$   $��16(�67   .��6E   Presentacion*6T   �� 5,      -   5        $ txbPresentacionn��5,      $	��180��64   6B   5-      �� 5.      $��16(�6   $��Arial)�6"   $��Italic$�65   .��6H   * Campos obligatorios6_   5/      � 50   
   $��2��6   .+�51      �� -   5         ��Name$ 	btnNuevoo��51       $��80��6   .��52      �� $ 
Horizontal=�6   .+�53      �� .��6   Nuevo6#   �� 54      $��16��6   $��/Imagenes/add.png��6'   6E   55      56      �� 57      -   5        $ btnGuardarr��57       $��80��6   .��58      �� $ 
Horizontal=�6   .+�59      �� .��6   	Guardar6%   �� 5:      $��16��6   $��/Imagenes/page_save.png��6'   6K   5;      5<      �� 5=      -	   5        $ 
btnEditarr��5=       $��80��6   .��5>      �� $ 
Horizontal=�6   .+�5?      �� .��6   Editar6$   �� 5@      $��16��6   $��/Imagenes/table_edit.png��6'   6L   5A      5B      �� 5C      -
   5        $ btnCancelarr��5C       $��80��6   .��5D      �� $ 
Horizontal=�6   .+�5E      �� .��6   
Cancelar6&   �� 5F      $��16��6   $��/Imagenes/Cancel.png��6'   6H   5G      5H      �� 5I      -   5        $ btnEliminarr��5I       $��80��6   .��5J      �� $ 
Horizontal=�6   .+�5K      �� .��6   
Eliminar6&   �� 5L      $��16��6   $$��/Imagenes/table_row_delete.png��6'   6R   5M      5N      �� 5O      -   5        $ btnRegresar��5O       $��80��6   .��5P      �� $ 
Horizontal=�6   .+�5Q      �� .��6   
Regresar6&   �� 5R      $��16��6   $#��/Imagenes/arrow_turn_left.png��6'   6Q   5S      5T      5U      &   System.Windows.Controls.DataGrid  5V   
   -   5          Name$ dtgTabla��5V         
IsReadOnly . $��3��67   5Y      5Z      