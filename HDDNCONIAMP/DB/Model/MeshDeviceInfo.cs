﻿using System.Data;
using Chloe.Entity;

namespace HDDNCONIAMP.DB.Model
{
    /// <summary>
    /// Mesh设备对象
    /// </summary>
    public class MeshDeviceInfo : IDEntity
    {
        /// <summary>
        /// 用户ID列，主键，自增
        /// </summary>
        [Column(IsPrimaryKey = true)]
        [AutoIncrement]
        public virtual int ID { get; set; }
        /// <summary>
        /// 分组名称，字符串格式
        /// </summary>
        [Column(DbType = DbType.String)]
        public string GroupName { get; set; }
        /// <summary>
        /// 设备别名，字符串格式
        /// </summary>
        [Column(DbType = DbType.String)]
        public string Alias { get; set; }
        /// <summary>
        /// 设备IPV4地址，字符串格式
        /// </summary>
        [Column(DbType = DbType.String)]
        public string IPV4 { get; set; }
        /// <summary>
        /// 设备功率，字符串格式
        /// </summary>
        [Column(DbType = DbType.Decimal)]
        public decimal Power { get; set; }
        /// <summary>
        /// 设备频率，字符串格式
        /// </summary>
        [Column(DbType = DbType.Decimal)]
        public decimal Frequency { get; set; }
        /// <summary>
        /// 设备带宽，字符串格式
        /// </summary>
        [Column(DbType = DbType.Decimal)]
        public decimal BandWidth { get; set; }
        /// <summary>
        /// 设备电压，字符串格式
        /// </summary>
        [Column(DbType = DbType.Decimal)]
        public decimal Battery { get; set; }

        /// <summary>
        /// 字符串转换
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "分组名称-" + GroupName +
                "别名-" + Alias +
                "Mesh IP-" + IPV4 +
                "功率-" + Power +
                "频率-" + Frequency +
                "带宽-" + BandWidth +
                "电量-" + Power;
        }
    }
}
