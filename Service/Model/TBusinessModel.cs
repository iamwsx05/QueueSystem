﻿using Chloe.Entity;

namespace Model
{
    /// <summary>
    /// 业务操作
    /// </summary>
    [Table("T_Business")]
    public class TBusinessModel
    {

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 业务所属部门名称
        /// </summary>
        public string unitName { get; set; }
        /// <summary>
        /// 业务所属部门ID
        /// </summary>
        public string unitSeq { get; set; }

        /// <summary>
        /// 预约业务流水号
        /// </summary>
        public string busiSeq { get; set; }

        /// <summary>
        /// 预约业务编号
        /// </summary>
        public string busiCode { get; set; }

        /// <summary>
        /// 预约业务名称
        /// </summary>
        public string busiName { get; set; }

        /// <summary>
        /// 预约类型。1-简单；2-详细
        /// </summary>
        public string busiType { get; set; }

        /// <summary>
        /// 是否可预约办件
        /// </summary>
        public bool acceptBusi { get; set; }

        /// <summary>
        /// 是否可预约领件
        /// </summary>
        public bool getBusi { get; set; }

        /// <summary>
        /// 是否可预约咨询
        /// </summary>
        public bool askBusi { get; set; }

        /// <summary>
        /// 同步状态：0:同步新增 1：同步修改 2：已同步 3：已删除
        /// </summary>
        public int sysFlag { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public int areaCode { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int areaId { get; set; }

        /// <summary>
        /// 是否投资的业务
        /// </summary>
        [NotMapped]
        public bool isInvestment { get; set; }
    }
}

