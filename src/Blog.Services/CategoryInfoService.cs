﻿using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Services
{
    public class CategoryInfoService : BaseService<CategoryInfo>, ICategoryInfoService
    {
        ICategoryInfoRepository _categoryInfoRepository;
        public CategoryInfoService(ICategoryInfoRepository categoryInfoRepository) : base(categoryInfoRepository)
        {
            _categoryInfoRepository = categoryInfoRepository;
        }

        /// <summary>
        /// 新增修改栏目
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public OperateResult Save(CategoryInfo category)
        {
            int count = QueryableCount(c => c.CategoryName == category.CategoryName && c.CategoryId != category.CategoryId);
            if (count > 0)
            {
                return new OperateResult("文章栏目已存在");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(category.CategoryId))
                {
                    category.CategoryId = SnowflakeUtil.NextStringId();
                    return InsertRemoveCache(category);
                }
                else
                {
                    if (category.CategoryId == category.ParentId)
                    {
                        return new OperateResult("上级栏目不能与当前栏目相同");
                    }
                    if (category.ParentId != "0")
                    {
                        var list = Queryable(m => m.DeleteMark == false && m.EnabledMark == true);
                        if (GetChildCategory(list, category.CategoryId).Where(o => o.CategoryId == category.ParentId).Any())
                        {
                            OperateResult result = new OperateResult();
                            result.Message = "无法将一级菜单指定到子级栏目下";
                            return result;
                        }
                    }
                    return UpdateRemoveCache(category, i => new { i.CreatorTime, i.DeleteMark });
                }
            }
        }

        /// <summary>
        /// 获取指定菜单下所有菜单
        /// </summary>
        /// <param name="list">所有菜单集合</param>
        /// <param name="id">指定菜单ID</param>
        /// <returns></returns>
        private List<CategoryInfo> GetChildCategory(List<CategoryInfo> list, string id)
        {
            List<CategoryInfo> modules = new List<CategoryInfo>();
            foreach (var item in list.Where(m => m.ParentId == id))
            {
                modules.Add(item);
                GetChildCategory(list, item.CategoryId);
            }
            return modules;
        }
    }
}
