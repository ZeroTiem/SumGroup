using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1_homeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TDD_Day1_homeWork.Tests
{
    [TestClass()]
    public class ProductTests
    {
        //參考500分同學作法
        //來源[https://github.com/bagamoon/SumByGroup]

        private List<Item> _items = new List<Item>();

        [TestInitialize()]
        public void Initialdata()
        {
            _items.Add(new Item { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21, name = "小明一" });
            _items.Add(new Item { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22, name = "小明二" });
            _items.Add(new Item { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23, name = "小明三" });
            _items.Add(new Item { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24, name = "小明四" });
            _items.Add(new Item { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25, name = "小明五" });
            _items.Add(new Item { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26, name = "小明六" });
            _items.Add(new Item { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27, name = "小明七" });
            _items.Add(new Item { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28, name = "小明八" });
            _items.Add(new Item { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29, name = "小明九" });
            _items.Add(new Item { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30, name = "小明十" }); 
            _items.Add(new Item { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31, name = "小明十一" });
        }


        [TestMethod()]
        public void 三筆一組取Cost總和()
        {
            //arrange
            Product Product = new Product();
            var expected = new List<int> { 6, 15, 24, 21 };
            //act
            var act = Product.SumGroup(_items, x => x.Cost, 3);
            //assert
            act.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void 四筆一組取Revenue總和()
        {
            //arrange
            Product Product = new Product();
            var expected = new List<int> { 50, 66, 60 };
            //act
            var act = Product.SumGroup(_items, x => x.Revenue, 4);
            //assert
            act.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void 五筆一組取SellPrice總和()
        {
            //arrange
            Product Product = new Product();
            var expected = new List<int> { 115, 140, 31 };
            //act
            var act = Product.SumGroup(_items, x => x.SellPrice, 5);
            //assert
            act.ShouldBeEquivalentTo(expected);
        }

        [TestMethod()]
        public void 三筆一組取name()
        {
            //arrange
            Product Product = new Product();
            var expected = new List<string> { "小明一小明二小明三", "小明四小明五小明六", "小明七小明八小明九", "小明十小明十一" };
            //act
            var act = Product.SumGroup(_items, x => x.name, 3);
            //assert
            act.ShouldBeEquivalentTo(expected);
        }


    }

    public class Item
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
        public string name { get; set; }
        public double _double { get; set; }
        public float _float { get; set; }
    }
}