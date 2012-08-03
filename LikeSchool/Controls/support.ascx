<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="support.ascx.cs" Inherits="LikeSchool.Controls.support" %>
<script type="text/javascript" src="../js/support.js"></script>
<div class="createSupport">
    <div class="modal hide" id="supportWindow">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h3>Help and Support</h3>
        </div>
        <div class="modal-body" id="supportElements">
            <div class="control-group">
                <label class="control-label" for="email">Enter your Email Address.[*]</label>
                <div class="controls">
                    <input class="span5" type="text" id="email" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="schoolName">School Name.[*]</label>
                <div class="controls">
                    <input class="span5" type="text" id="schoolName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="sDesc">What do you need help with?[*]</label>
                <div class="controls">
                    <input type="text" class="span8" id="sDesc" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="description">
                    Describe your problem/question in detail[*]
                </label>
                <div class="controls">
                    <textarea id="description" class="span8"></textarea>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" id="clearAll"><i class="icon-remove icon-black"></i>Clear All
            </a><a href="#" class="btn btn-info" id="submitSupport"><i class="icon-plus icon-black"></i>Submit
            </a>
        </div>
    </div>
    <div class="modal hide" id="thanksWindow">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        <h1>Thanks for submitting the ticket.</h1>
    </div>
</div>
