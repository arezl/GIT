﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{/// <summary>
 /// 商品
 /// </summary>

    class Product
    {
        public virtual Guid ID { get; set; }
        public virtual string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public virtual string QuantityPerUnit { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public virtual decimal SellPrice { get; set; }

        /// <summary>
        /// 进价
        /// </summary>
        public virtual decimal BuyPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
    }
}
