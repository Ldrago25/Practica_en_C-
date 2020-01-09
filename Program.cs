using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {

        static void tags(String revisar)
        {
            
            String[] cierre=new String[100];
            String[] apertura=new String[100];
            int j=0; int k=0;
           // Console.Write("Cadena: "+revisar);
            //que locura voy hacer x_x
             for(int i=0; i<revisar.Length; i++)
            {
                String con="";
                if(revisar[i]=='<')
                {
                    i++;
                    if(revisar[i]=='/')
                    {
                        con+='<';
                       // con+=revisar[i];
                        i++;
                        if(revisar[i]!='>'&&char.IsUpper(revisar[i]))
                        {
                            con+=revisar[i];
                            i++;
                            if(revisar[i]=='>')
                            {
                                con+=revisar[i];
                                cierre[k]=con;
                               k++;

                            }
                        }
                    }else if(revisar[i]!='>'&&char.IsUpper(revisar[i]))
                    {
                        con+='<';
                        con+=revisar[i];
                        i++;
                         if(revisar[i]=='>')
                        {
                            con+=revisar[i];
                            apertura[j]=con;
                            j++;
                         }
                    }
                }
               
                
            }
           

           /* Console.Write("Tags Apertura");
            Console.WriteLine();
            for(int i=0; i<j; i++)
            {
                Console.WriteLine(apertura[i]);
            }
            Console.Write("Tags Cierre");
           Console.WriteLine();
            for(int i=0; i<k; i++)
            {
                Console.WriteLine(cierre[i]);
            }*/
            bool bn=false;
            if(j==k)
            {  
                int size=j; 
                bool rompo=false;
                for(int i=0; i<j; i++)
                {
                   /*  Console.Write("Apertura: "+apertura[size-1]);
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.Write("Cierre: "+cierre[i]);
                    Console.ReadKey();*/
                    if(apertura[size-1]==cierre[i])
                    {
                        bn=true;
                        size--;
                    }else
                    {
                        String conteo="";
                        String c2="";
                        String conteo3="";
                        String c4="";
                        conteo+=cierre[i+1];
                        conteo3+=cierre[i];
                        for(int f=0; f<conteo.Length; f++)
                        {
                            c2+=conteo[f];
                            c4+=conteo3[f];
                            if(c2[f]=='<')
                            {
                                c2+='/';
                            }
                            if(c4[f]=='<')
                            {
                                c4+='/';
                            }
                        }
                        
                        Console.Write("Expected "+c2+"found "+c4);
                        Console.WriteLine();
                        break; rompo=true;
                    }
                    if(rompo)break;
                   
                }
                 if(bn)
                 {
                     Console.Write("Correctly tagged paragraph");
                     Console.WriteLine();
                 } 
            }else if(j>k)
            {
                int tama=j;
                String acum="";
                String acum2="";
                bool bandera=false;
                for(int i=0; i<k; i++)
                {
                    for(int y=0; y<j; y++)
                    {
                        if(cierre[i]!=apertura[y])
                        {
                            acum+=apertura[y];
                            for (int z = 0; z < acum.Length; z++)
                            {
                                acum2+=acum[z];
                                if(acum2[z]=='<')
                                {
                                    acum2+='/';
                                }
                            }
                           
                                Console.Write("Expected "+acum2+" found #");
                                Console.WriteLine();
                                bandera=true;
                        }
                        if(bandera)break;
                    }
                }
            }else
            {
                 int tamas=k;
                 String save="";
                 String save2="";
                 bool brea=false;

                 for(int i=0; i<j; i++)
                 {
                     for(int y=0; y<k; y++)
                     {
                        if(apertura[i]!=cierre[y])
                        {
                            save+=cierre[y];
                            for(int z=0; z<save.Length; z++)
                            {
                                save2+=save[z];
                                if(save[z]=='<')
                                {
                                    save2+='/';
                                }
                            }
                            Console.WriteLine("Expected # Found "+save2);
                            brea=true;
                        }
                        if(brea)break;
                     }
                 }
            }
        }


        static void Main(string[] args)
        {
             using(StreamReader archivito=new StreamReader(@"C:\Users\WINDOWS 8.1\Music\proyecto3\Tag.txt"))
            {
                while(!archivito.EndOfStream)
                {
                    String linea="";
                while(true)
                {
                    linea+=archivito.ReadLine();
                    if(linea.Contains("#")) break;
                }
               // Console.Write("Cadena: "+linea);
               // Console.ReadKey();
               if(linea=="#")break;
               tags(linea);
              // Console.ReadKey();
                }
            }
           
            
        }
    }
}
