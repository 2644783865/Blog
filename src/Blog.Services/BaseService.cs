﻿using Blog.Common.Log;
using Blog.Core;
using Blog.Entities.Dtos;
using Blog.IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 插入数据（适用于id自动增长）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回主键ID</returns>
        public virtual OperateResult InsertScalar(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.InsertScalar(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// 插入数据（适用于id自动增长）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回主键ID</returns>
        public virtual OperateResult InsertScalarRemoveCache(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.InsertScalarRemoveCache(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// 插入数据（适用于id自动增长）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回主键ID</returns>
        public virtual async Task<OperateResult> InsertScalarAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertScalarAsync(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 插入数据（适用于id自动增长）并删除缓存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperateResult> InsertScalarRemoveCacheAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertScalarRemoveCacheAsync(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        public virtual OperateResult Insert(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Insert(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 插入数据并清除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        public virtual OperateResult InsertRemoveCache(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.InsertRemoveCache(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        public virtual async Task<OperateResult> InsertAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertAsync(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        public virtual async Task<OperateResult> InsertRemoveCacheAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertRemoveCacheAsync(entity) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        public virtual OperateResult Insert(List<TEntity> entities)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Insert(entities) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        public virtual OperateResult InsertRemoveCache(List<TEntity> entities)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.InsertRemoveCache(entities) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> InsertAsync(List<TEntity> entities)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertAsync(entities) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量添加（异步）并删除缓存
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> InsertRemoveCacheAsync(List<TEntity> entities)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.InsertRemoveCacheAsync(entities) > 0 ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        public virtual OperateResult Update(TEntity entity, bool isNoUpdateNull = false)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Update(entity, isNoUpdateNull) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过主键修改（包含是否需要将null值字段提交到数据库）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        public virtual OperateResult UpdateRemoveCache(TEntity entity, bool isNoUpdateNull = false)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.UpdateRemoveCache(entity, isNoUpdateNull) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateAsync(TEntity entity, bool isNoUpdateNull = false)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateAsync(entity, isNoUpdateNull) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过主键修改（包含是否需要将null值字段提交到数据库）异步，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, bool isNoUpdateNull = false)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateRemoveCacheAsync(entity, isNoUpdateNull) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改（更新实体部分字段）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        public virtual OperateResult Update(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Update(entity, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改（更新实体部分字段）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        public virtual OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.UpdateRemoveCache(entity, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改（更新实体部分字段）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateAsync(entity, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改（更新实体部分字段）异步，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateRemoveCacheAsync(entity, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过条件更新(不更新忽略字段)
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        public virtual OperateResult Update(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Update(entity, expression, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过条件更新(不更新忽略字段),并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        public virtual OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.UpdateRemoveCache(entity, expression, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过条件更新(不更新忽略字段)异步
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateAsync(entity, expression, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过条件更新(不更新忽略字段)异步,并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateRemoveCacheAsync(entity, expression, ignoreColumns) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual OperateResult Update(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Update(entity, expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过条件修改，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.UpdateRemoveCache(entity, expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateAsync(entity, expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateRemoveCacheAsync(entity, expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        public virtual OperateResult Update(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Update(expression, condition) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        public virtual OperateResult UpdateRemoveCache(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.UpdateRemoveCache(expression, condition) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改指定字段
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateAsync(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateAsync(expression, condition) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 修改指定字段并删除缓存
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> UpdateRemoveCacheAsync(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.UpdateRemoveCacheAsync(expression, condition) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual OperateResult Delete(dynamic keyValue)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Delete(keyValue) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual OperateResult DeleteRemoveCache(dynamic keyValue)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.DeleteRemoveCache(keyValue) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteAsync(dynamic keyValue)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteAsync(keyValue) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除(异步)并删除缓存
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteRemoveCacheAsync(dynamic keyValue)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteRemoveCacheAsync(keyValue) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        // <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        public virtual OperateResult Delete(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Delete(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        // <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        public virtual OperateResult DeleteRemoveCache(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.DeleteRemoveCache(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        // <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        public virtual async Task<OperateResult> DeleteAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteAsync(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        // <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        public virtual async Task<OperateResult> DeleteRemoveCacheAsync(TEntity entity)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteRemoveCacheAsync(entity) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual OperateResult Delete(Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Delete(expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual OperateResult DeleteRemoveCache(Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.DeleteRemoveCache(expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteAsync(expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 删除（异步）并删除缓存
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteRemoveCacheAsync(Expression<Func<TEntity, bool>> expression)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = await _repository.DeleteRemoveCacheAsync(expression) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        public virtual OperateResult Delete(List<dynamic> keys)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.Delete(keys) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量删除并删除缓存
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        public virtual OperateResult DeleteRemoveCache(List<dynamic> keys)
        {
            OperateResult result = new OperateResult();
            try
            {
                result.Status = _repository.DeleteRemoveCache(keys) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteAsync(List<dynamic> keys)
        {
            OperateResult result = new OperateResult();
            try
            {

                result.Status = await _repository.DeleteAsync(keys) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 批量删除（异步）并删除缓存
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        public virtual async Task<OperateResult> DeleteRemoveCacheAsync(List<dynamic> keys)
        {
            OperateResult result = new OperateResult();
            try
            {

                result.Status = await _repository.DeleteRemoveCacheAsync(keys) ? ResultStatus.Success : ResultStatus.Error;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                NLogger.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual TEntity FindEntity(object keyValue)
        {
            return _repository.FindEntity(keyValue);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual TEntity FindEntity(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.FindEntity(expression);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.FindEntityAsync(expression);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        /// <summary>
        /// 获取所有集合(缓存)
        /// </summary>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryableCache(int s = int.MaxValue)
        {
            return _repository.QueryableCache(s);
        }

        /// <summary>
        /// 检查信息总条数
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual int QueryableCount(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.QueryableCount(expression);
        }

        /// <summary>
        /// 检查信息总条数
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public virtual async Task<int> QueryableCountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.QueryableCountAsync(expression);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableAsync()
        {
            return await _repository.QueryableAsync();
        }

        /// <summary>
        /// 获取所有集合(缓存)
        /// </summary>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableCacheAsync(int s = int.MaxValue)
        {
            return await _repository.QueryableCacheAsync(s);
        }

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">条件</param>
        public virtual List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Queryable(expression);
        }

        /// <summary>
        /// 根据条件获取集合并加入缓存
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        public List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, int s = int.MaxValue)
        {
            return _repository.QueryableCache(expression, s);
        }

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">条件</param>
        public virtual async Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.QueryableAsync(expression);
        }

        /// <summary>
        /// 根据条件获取集合(缓存)
        /// </summary>
        /// <param name="expression">条件Lambda表达式</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        public virtual async Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, int s = int.MaxValue)
        {
            return await _repository.QueryableCacheAsync(expression, s);
        }

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <returns>集合</returns>
        public virtual List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc)
        {
            return _repository.Queryable(expression, orderby, isDesc);
        }

        /// <summary>
        /// 根据条件获取集合(缓存)
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        public virtual List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int s = int.MaxValue)
        {
            return _repository.QueryableCache(expression, orderby, isDesc, s);
        }

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <returns>集合</returns>
        public virtual async Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc)
        {
            return await _repository.QueryableAsync(expression, orderby, isDesc);
        }

        /// <summary>
        /// 根据条件获取集合(缓存)异步
        /// </summary>
        /// <param name="expression">条件Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        public virtual async Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int s = int.MaxValue)
        {
            return await _repository.QueryableCacheAsync(expression, orderby, isDesc, s);
        }

        /// <summary>
        /// 根据条件获取指定条数集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <returns>集合</returns>
        public virtual List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top)
        {
            return _repository.Queryable(expression, orderby, isDesc, top);
        }

        /// <summary>
        /// 根据条件获取指定条数集合(缓存)
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        public virtual List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top, int s = int.MaxValue)
        {
            return _repository.QueryableCache(expression, orderby, isDesc, top, s);
        }

        /// <summary>
        /// 根据条件获取指定条数集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <returns>集合</returns>
        public virtual async Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top)
        {
            return await _repository.QueryableAsync(expression, orderby, isDesc, top);
        }

        /// <summary>
        /// 根据条件获取指定条数集合(缓存)异步
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        public virtual async Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top, int s = int.MaxValue)
        {
            return await _repository.QueryableCacheAsync(expression, orderby, isDesc, top, s);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>集合|总条数</returns>
        public virtual Tuple<List<TEntity>, int> QueryableByPage(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int pageIndex, int pageSize)
        {
            return _repository.QueryableByPage(expression, orderby, isDesc, pageIndex, pageSize);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">多字段排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>集合|总条数</returns>
        public virtual Tuple<List<TEntity>, int> QueryableByPage(Expression<Func<TEntity, bool>> expression, Dictionary<Expression<Func<TEntity, object>>, OrderByType> orderby, int pageIndex, int pageSize)
        {
            return _repository.QueryableByPage(expression, orderby, pageIndex, pageSize);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="conditionals">查询条件</param>
        /// <param name="orderFileds">排序字段</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public virtual Tuple<List<TEntity>, int> QueryableByPage(List<IConditionalModel> conditionals, string orderFileds, int pageIndex, int pageSize)
        {
            return _repository.QueryableByPage(conditionals, orderFileds, pageIndex, pageSize);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model">分页查询实体</param>
        /// <returns></returns>
        public virtual PageResult<List<TEntity>> QueryableByPage(QueryDto model)
        {
            PageResult<List<TEntity>> result = new PageResult<List<TEntity>>();
            var page = _repository.QueryableByPage(model.ConditionalModels, model.order, model.page, model.limit);
            result.data = page.Item1;
            result.count = page.Item2;
            return result;
        }
    }
}
