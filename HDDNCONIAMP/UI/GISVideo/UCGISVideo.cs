﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using log4net;

namespace HDDNCONIAMP.UI.GISVideo
{
    /// <summary>
    /// GIS定位关联视频控件
    /// </summary>
    public partial class UCGISVideo : UserControl
    {

        #region 私有字段

        /// <summary>
        /// 日志记录器
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UCGISVideo));

        /// <summary>
        /// 当前新建分组索引编号
        /// </summary>
        private static int sCurrentNewGroupIndex = 0;

        #endregion

        public UCGISVideo()
        {
            InitializeComponent();

            //默认隐藏检索结果列表节点
            nodeSearchResult.Visible = false;
        }

        #region 设备列表事件


        private void textBoxXSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 展开所有树节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItemExpandAll_Click(object sender, EventArgs e)
        {
            advTreeDeviceList.ExpandAll();
            buttonItemExpandAll.Enabled = false;
            buttonItemFoldAll.Enabled = true;
        }

        /// <summary>
        /// 折叠所有树节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItemFoldAll_Click(object sender, EventArgs e)
        {
            advTreeDeviceList.CollapseAll();
            buttonItemExpandAll.Enabled = true;
            buttonItemFoldAll.Enabled = false;

        }

        private void buttonItemAddGroup_Click(object sender, EventArgs e)
        {
            Node node = new Node("新建分组" + sCurrentNewGroupIndex);
            node.ImageIndex = 5;
            node.ImageExpandedIndex = 4;
            advTreeDeviceList.Nodes.Add(node);
            sCurrentNewGroupIndex++;
            logger.Info("添加分组“"+node.Text+ "”。");
        }

        private void buttonItemDeleteGroup_Click(object sender, EventArgs e)
        {
            Node selectedNode = advTreeDeviceList.SelectedNode;
            if(selectedNode == null)
            {
                MessageBox.Show("未选择任何分组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedNode == nodeDefaultGroup)
            {
                MessageBox.Show("默认分组不能删除！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(selectedNode.Level == 0)
            {
                if(DialogResult.OK == MessageBox.Show("确认删除分组“"+selectedNode.Text+"”？", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    try
                    {
                        advTreeDeviceList.Nodes.Remove(selectedNode);
                        logger.Info("删除分组“" + selectedNode.Text + "”。");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除分组“" + selectedNode.Text + "”失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("删除分组“" + selectedNode.Text + "”失败！\n", ex);
                    }
                }
            }
            
        }

        #endregion

        #region 地图控件工具栏事件

        private void buttonItemBMapDrag_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItemBMapZoomIn_Click(object sender, EventArgs e)
        {
            bMapControlMain.Zoom = bMapControlMain.Zoom >= 18 ? 18 : (bMapControlMain.Zoom++);
        }

        private void buttonItemBMapZoomout_Click(object sender, EventArgs e)
        {
            bMapControlMain.Zoom = bMapControlMain.Zoom <=3  ? 3 : (bMapControlMain.Zoom--);
        }

        #endregion

    }
}
