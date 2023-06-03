using BanderaHammer.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
        private UnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = new UnitOfWork();
        }

        [Test, Order(1)]
        public void AddStorage()
        {
            try
            {
                _unitOfWork.StorageService.AddStorage(new BLL.Storage { Name = "test", Path = "test" });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }

            Assert.Pass("Added storage");

        }

        [Test, Order(2)]
        public void GetStorage()
        {
            List<BLL.Storage> storages = new List<BLL.Storage>();

            try
            {
                storages = _unitOfWork.StorageService.GetStorages("test");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }


            Assert.IsNotEmpty(storages);
        }

        [Test, Order(3)]
        public void AddSource()
        {
            try
            {
                var storages = _unitOfWork.StorageService.GetStorages("test");
                _unitOfWork.SourceService.AddSource(new BLL.Source { FileName = "test", Name = "test", Type = BLL.SourceType.Book }, storages[0].Id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }


            Assert.Pass("Added source");
        }

        [Test, Order(4)]
        public void GetSource()
        {
            List<BLL.Source> sources = new List<BLL.Source>();

            try
            {
                sources = _unitOfWork.SourceService.GetSources("test");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }
            Assert.IsNotEmpty(sources);

        }

        [Test, Order(5)]
        public void RemoveSource()
        {
            try
            {
                var sources = _unitOfWork.SourceService.GetSources("test");

                _unitOfWork.SourceService.RemoveSource(sources[0].Id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }
            Assert.Pass();

        }

        [Test, Order(6)]
        public void RemoveStorage()
        {
            try
            {
                var storages = _unitOfWork.StorageService.GetStorages("test");

                _unitOfWork.SourceService.RemoveSource(storages[0].Id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + e.StackTrace);
            }
            Assert.Pass();

        }
    }
}