   M S B A M L   `   `   `  ����V  RSteganografia-implementacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Steganografia_implementacjaSteganografia_implementacja  5      %    Steganografia_implementacja.LSB   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Steganografia_implementacja     5      $	��609��5      $	��939��6,   .��5      � $��
0,12,14,-2q�6   .+�5	   
   �� -   5        $��Wczytaj��5	      $
��Left=�6#   $��
45,340,0,0q�6>   $	��Top=�6R   $��74��6j   6u   �� 5
   
   -   5          ��Name$  Obraz��5
      $
��Left=�6   $	��269��6:   $��	40,64,0,0q�6G   $	��Top=�6Z   $	��394��6r   �� 5   
   -   5         ��Name$ tekst��5      $
��Left=�6!   $	��109��6<   $��
29,385,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��224��6�   �� 5   
   -   5        $��Ukryj��5      $
��Left=�6!   $��
33,547,0,0q�6<   $	��Top=�6P   $��76��6h   $��21��6�   �� 5   
   -   5        $  Obraz1��5      $
��Left=�6    $	��268��6;   $��
488,67,0,0q�6H   $	��Top=�6\   $	��394��6t   �� 5   
   -   5        $��Zapisz��5      $
��Left=�6"   $��20��6=   $��115,549,0,0q�6I   $	��Top=�6^   $��76��6v   6�   �� 5   
   -   5        $��Odkryj��5      $
��Left=�6"   $��22��6=   $��459,544,0,0q�6I   $	��Top=�6^   $��62��6v    J� RenderTransformOrigin$ 1.226,0.273&�6�   6�   �� 5   
   -   5        $��Wczytaj��5      $
��Left=�6#   $��492,339,0,0q�6>   $	��Top=�6S   $��76��6k   6v   �� 5   
   $��Oryginalny plik��6   $
��Left=�6*   $��	36,30,0,0q�6E   $	��Top=�6X   �� 5   
   $ ��Plik z ukrytą informacją��6   $
��Left=�63   $��
488,24,0,0q�6N   $	��Top=�6b   �� 5   
   $��Informacja do ukrycia��6   $
��Left=�60   $��
34,362,0,0q�6K   $	��Top=�6_   �� 5   
   $��Ukryta informacja��6   $
��Left=�6,   $��452,356,0,0q�6G   $	��Top=�6\   �� 5   
   -	   5        $ tekst2��5      $
��Left=�6"   $	��109��6=   $��452,381,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��224��6�   �� 5   
   -
   5        $ start��5      $
��Left=�6!   $��23��6<   $��
34,519,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��126��6�   �� 5   
   $��Początek zapisu ��6   $
��Left=�6+   $��
32,496,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $ start2��5      $
��Left=�6"   $��23��6=   $��456,515,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��126��6�   �� 5   
   $��Początek odczytu ��6   $
��Left=�6,   $��454,492,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $��?��5      $
��Left=�6   $��841,527,0,0q�68   $	��Top=�6M   $��75��6e   $��49��6p   $��22(�6�   �� 5   
   -   5        $��Wczytaj tekst��5      $
��Left=�6)   $��179,502,0,0q�6D   $	��Top=�6Y   $��75��6q   6|   5      5      