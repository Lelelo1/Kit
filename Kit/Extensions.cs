using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace Namespace
{
    public static class Extensions 
    {
        /* Could use with 3 options: find nearest (any) Layout, find nearest Layout<View>, or find nearest ContentView */
        /* works */
        public static Element RootLayout(this Element element, bool layoutWithChildren = false)
        {
            return FindRootLayout(element, layoutWithChildren);
        }
        static Element FindRootLayout(Element element, bool layoutWithChildren)
        {

            if (element.Parent is Page)
            {
                // found end
                if (layoutWithChildren)
                {
                    if (element is ContentView c)
                    {
                        return FindNearestLayoutWithChildren(c);
                    }
                    else
                    {
                        PrintError(element);
                        return null;
                    }
                }
                else
                {

                    return element;
                }

            }

            return FindRootLayout(element.Parent, layoutWithChildren);
        }
        static Element FindNearestLayoutWithChildren(Element element)
        {
            if(element is ContentView c)
            {

                return FindNearestLayoutWithChildren(c.Content);
            }
            else if(element is Layout<View>)
            {

                return element;
            }
            else
            {
                return null;
            }
        }

        /* Used by TopContentView And Draggable. Unlcear if there is other usecases for it */
        /*
        public static Layout PositionedOnLayout(this Element element)
        {
            var root = element.RootLayout();


        }
        */

        /* list all layouts in the page */
        public static List<Element> AllLayouts(this Element element)
        {
            var root = element.RootLayout();
            Layouts = new List<Element>();
            AddLayout(root);
            var list = Layouts;
            Layouts = null;
            return list;
        }
        static List<Element> Layouts;
        static Element AddLayout(Element element)
        {

            if(element is ContentView c)
            {
                Layouts.Add(c);
                if(c.Content != null)
                {
                    AddLayout(c.Content);
                }
            }
            else if(element is Layout<View> l)
            {
                Layouts.Add(l);
                foreach(var child in l.Children)
                {
                    AddLayout(child);
                }
            }
            else
            {
                // is control or TemplatedView or ContentPresenter
            }
            return element;
        }
        static void PrintError(Element element)
        {
            // was TemplatedView or ContentPresenter: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/layouts 
            Console.WriteLine("Warning: Non supported layout type. Was: " + element + ". Should be of ContentView/Frame or Layout<View>");
        }
         
    }
}
