   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=4.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   P LMultiformEmployeeInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MultiformEmployeeInfoMultiformEmployeeInfo 5   	   &    MultiformEmployeeInfo.EditWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   5local#clr-namespace:MultiformEmployeeInfo     5   	     � Title$  Edit Employee��5	   	   $	��250��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��Employee Id��6-   $��Center=�5      $��Right=�62   $��5q�6U   6b   �� 5   
   $��1��6   $��0��6   $��Employee Name��6-   $��Center=�5      $��Right=�62   $��5q�6U   6b   �� 5   
   $��2��6   $��0��6   $��Employee Position��6-   $��Center=�5      $��Right=�62   $��5q�6U   6b   �� 5   
   $��3��6   $��0��6   $��Employee Hourly Rate��6-   $��Center=�5      $��Right=�62   $��5q�6U   6b   &    Xceed.Wpf.Toolkit.UIntegerUpDown  5   
   -   5        $��
EmployeeID��5   .   $��0��6!   $��1��6@   $��5q�6P   �   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.UInt32, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 6[   �� *Emp_Id+�� 5    
   $��1��6   $��1��6   $��5q�6/   ��6:   �� *Name+6R   �� 5!   
   $��2��6   $��1��6   $��5q�6/   ��6:   �� *
Position+6V   �� 5"   
   $��3��6   $��1��6   $��5q�6/   ��6:   �� *Hourly_rate+6Y   �� 5%   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   .+�5&      �� -   5        $
��Save��5&      $
��Save��6!   $��5q�60   $��50��6;   6^   �� 5'      -   5        $��Cancel��5'      $��Cancel��6#   $��5q�64   $��50��6?   6d   5(      5)      5*      