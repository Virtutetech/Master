<%@ Page Title="Add Address" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="AddAddress.aspx.vb" Inherits="AddAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
        <div class="page-title">
          <h1>Checkout</h1>
        </div>
        <ol class="one-page-checkout" id="checkoutSteps">
          <li id="opc-login" class="section">
            <div class="step-title"> <span class="number">1</span>
              <h3 class="one_page_heading">Checkout Method</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
          </li>
          <li id="opc-billing" class="section allow active">
            <div class="step-title"> <span class="number">2</span>
              <h3 class="one_page_heading">Billing Information</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-billing" class="step a-item">
              <form id="co-billing-form">
                <fieldset class="group-select">
                  <ul>
                    <li id="billing-new-address-form">
                      <fieldset>
                        <legend>New Address</legend>
                        <input type="hidden" name="billing[address_id]" />
                        <ul>
                          <li>
                            <div class="customer-name">
                              <div class="input-box name-firstname">
                                <label> First Name<span class="required">*</span></label>
                                <br />
                                <input type="text" name="billing[firstname]" title="First Name" class="input-text" />
                              </div>
                              <div class="input-box name-lastname">
                                <label> Last Name<span class="required">*</span> </label>
                                <br />
                                <input type="text" name="billing[lastname]" title="Last Name" class="input-text" />
                              </div>
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Company</label>
                              <br />
                              <input type="text" name="billing[company]" title="Company" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Email Address <span class="required">*</span></label>
                              <br />
                              <input type="text" name="billing[email]" title="Email Address" class="input-text" />
                            </div>
                          </li>
                          <li>
                            <label>Address <span class="required">*</span></label>
                            <br />
                            <input type="text" title="Street Address" name="billing[street][]" class="input-text" />
                          </li>
                          <li>
                            <input type="text" title="Street Address 2" name="billing[street][]" class="input-text" />
                          </li>
                          <li>
                            <div class="input-box">
                              <label>City <span class="required">*</span></label>
                              <br />
                              <input type="text" title="City" name="billing[city]" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>State/Province <span class="required">*</span></label>
                              <br />
                              <select id="billing:region_id" name="billing[region_id]" title="State/Province" class="validate-select">
                                <option>Please select region, state or province</option>
                                <option value="1">Alabama</option>
                                <option value="2">Alaska</option>
                                <option value="3">American Samoa</option>
                                <option value="4">Arizona</option>
                                <option value="5">Arkansas</option>
                                <option value="6">Armed Forces Africa</option>
                                <option value="7">Armed Forces Americas</option>
                                <option value="8">Armed Forces Canada</option>
                                <option value="9">Armed Forces Europe</option>
                                <option value="10">Armed Forces Middle East</option>
                                <option value="11">Armed Forces Pacific</option>
                                <option value="12">California</option>
                                <option value="13">Colorado</option>
                                <option value="14">Connecticut</option>
                                <option value="15">Delaware</option>
                                <option value="16">District of Columbia</option>
                                <option value="17">Federated States Of Micronesia</option>
                                <option value="18">Florida</option>
                                <option value="19">Georgia</option>
                                <option value="20">Guam</option>
                                <option value="21">Hawaii</option>
                                <option value="22">Idaho</option>
                                <option value="23">Illinois</option>
                                <option value="24">Indiana</option>
                                <option value="25">Iowa</option>
                                <option value="26">Kansas</option>
                                <option value="27">Kentucky</option>
                                <option value="28">Louisiana</option>
                                <option value="29">Maine</option>
                                <option value="30">Marshall Islands</option>
                                <option value="31">Maryland</option>
                                <option value="32">Massachusetts</option>
                                <option value="33">Michigan</option>
                                <option value="34">Minnesota</option>
                                <option value="35">Mississippi</option>
                                <option value="36">Missouri</option>
                                <option value="37">Montana</option>
                                <option value="38">Nebraska</option>
                                <option value="39">Nevada</option>
                                <option value="40">New Hampshire</option>
                                <option value="41">New Jersey</option>
                                <option value="42">New Mexico</option>
                                <option value="43">New York</option>
                                <option value="44">North Carolina</option>
                                <option value="45">North Dakota</option>
                                <option value="46">Northern Mariana Islands</option>
                                <option value="47">Ohio</option>
                                <option value="48">Oklahoma</option>
                                <option value="49">Oregon</option>
                                <option value="50">Palau</option>
                                <option value="51">Pennsylvania</option>
                                <option value="52">Puerto Rico</option>
                                <option value="53">Rhode Island</option>
                                <option value="54">South Carolina</option>
                                <option value="55">South Dakota</option>
                                <option value="56">Tennessee</option>
                                <option value="57">Texas</option>
                                <option value="58">Utah</option>
                                <option value="59">Vermont</option>
                                <option value="60">Virgin Islands</option>
                                <option value="61">Virginia</option>
                                <option value="62">Washington</option>
                                <option value="63">West Virginia</option>
                                <option value="64">Wisconsin</option>
                                <option value="65">Wyoming</option>
                              </select>
                              <input type="text" id="billing:region" name="billing[region]" title="State/Province" class="input-text">
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Zip/Postal Code <span class="required">*</span></label>
                              <br />
                              <input type="text" title="Zip/Postal Code" name="billing[postcode]" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Country <span class="required">*</span></label>
                              <br />
                              <select name="billing[country_id]" class="validate-select" title="Country">
                                <option value="AF">Afghanistan</option>
                                <option value="AL">Albania</option>
                                <option value="DZ">Algeria</option>
                                <option value="AS">American Samoa</option>
                                <option value="AD">Andorra</option>
                                <option value="AO">Angola</option>
                                <option value="AI">Anguilla</option>
                                <option value="AQ">Antarctica</option>
                                <option value="AG">Antigua and Barbuda</option>
                                <option value="AR">Argentina</option>
                                <option value="AM">Armenia</option>
                                <option value="AW">Aruba</option>
                                <option value="AU">Australia</option>
                                <option value="AT">Austria</option>
                                <option value="AZ">Azerbaijan</option>
                                <option value="BS">Bahamas</option>
                                <option value="BH">Bahrain</option>
                                <option value="BD">Bangladesh</option>
                                <option value="BB">Barbados</option>
                                <option value="BY">Belarus</option>
                                <option value="BE">Belgium</option>
                                <option value="BZ">Belize</option>
                                <option value="BJ">Benin</option>
                                <option value="BM">Bermuda</option>
                                <option value="BT">Bhutan</option>
                                <option value="BO">Bolivia</option>
                                <option value="BA">Bosnia and Herzegovina</option>
                                <option value="BW">Botswana</option>
                                <option value="BV">Bouvet Island</option>
                                <option value="BR">Brazil</option>
                                <option value="IO">British Indian Ocean Territory</option>
                                <option value="VG">British Virgin Islands</option>
                                <option value="BN">Brunei</option>
                                <option value="BG">Bulgaria</option>
                                <option value="BF">Burkina Faso</option>
                                <option value="BI">Burundi</option>
                                <option value="KH">Cambodia</option>
                                <option value="CM">Cameroon</option>
                                <option value="CA">Canada</option>
                                <option value="CV">Cape Verde</option>
                                <option value="KY">Cayman Islands</option>
                                <option value="CF">Central African Republic</option>
                                <option value="TD">Chad</option>
                                <option value="CL">Chile</option>
                                <option value="CN">China</option>
                                <option value="CX">Christmas Island</option>
                                <option value="CC">Cocos [Keeling] Islands</option>
                                <option value="CO">Colombia</option>
                                <option value="KM">Comoros</option>
                                <option value="CG">Congo - Brazzaville</option>
                                <option value="CD">Congo - Kinshasa</option>
                                <option value="CK">Cook Islands</option>
                                <option value="CR">Costa Rica</option>
                                <option value="HR">Croatia</option>
                                <option value="CU">Cuba</option>
                                <option value="CY">Cyprus</option>
                                <option value="CZ">Czech Republic</option>
                                <option value="CI">Côte d’Ivoire</option>
                                <option value="DK">Denmark</option>
                                <option value="DJ">Djibouti</option>
                                <option value="DM">Dominica</option>
                                <option value="DO">Dominican Republic</option>
                                <option value="EC">Ecuador</option>
                                <option value="EG">Egypt</option>
                                <option value="SV">El Salvador</option>
                                <option value="GQ">Equatorial Guinea</option>
                                <option value="ER">Eritrea</option>
                                <option value="EE">Estonia</option>
                                <option value="ET">Ethiopia</option>
                                <option value="FK">Falkland Islands</option>
                                <option value="FO">Faroe Islands</option>
                                <option value="FJ">Fiji</option>
                                <option value="FI">Finland</option>
                                <option value="FR">France</option>
                                <option value="GF">French Guiana</option>
                                <option value="PF">French Polynesia</option>
                                <option value="TF">French Southern Territories</option>
                                <option value="GA">Gabon</option>
                                <option value="GM">Gambia</option>
                                <option value="GE">Georgia</option>
                                <option value="DE">Germany</option>
                                <option value="GH">Ghana</option>
                                <option value="GI">Gibraltar</option>
                                <option value="GR">Greece</option>
                                <option value="GL">Greenland</option>
                                <option value="GD">Grenada</option>
                                <option value="GP">Guadeloupe</option>
                                <option value="GU">Guam</option>
                                <option value="GT">Guatemala</option>
                                <option value="GG">Guernsey</option>
                                <option value="GN">Guinea</option>
                                <option value="GW">Guinea-Bissau</option>
                                <option value="GY">Guyana</option>
                                <option value="HT">Haiti</option>
                                <option value="HM">Heard Island and McDonald Islands</option>
                                <option value="HN">Honduras</option>
                                <option value="HK">Hong Kong SAR China</option>
                                <option value="HU">Hungary</option>
                                <option value="IS">Iceland</option>
                                <option value="IN">India</option>
                                <option value="ID">Indonesia</option>
                                <option value="IR">Iran</option>
                                <option value="IQ">Iraq</option>
                                <option value="IE">Ireland</option>
                                <option value="IM">Isle of Man</option>
                                <option value="IL">Israel</option>
                                <option value="IT">Italy</option>
                                <option value="JM">Jamaica</option>
                                <option value="JP">Japan</option>
                                <option value="JE">Jersey</option>
                                <option value="JO">Jordan</option>
                                <option value="KZ">Kazakhstan</option>
                                <option value="KE">Kenya</option>
                                <option value="KI">Kiribati</option>
                                <option value="KW">Kuwait</option>
                                <option value="KG">Kyrgyzstan</option>
                                <option value="LA">Laos</option>
                                <option value="LV">Latvia</option>
                                <option value="LB">Lebanon</option>
                                <option value="LS">Lesotho</option>
                                <option value="LR">Liberia</option>
                                <option value="LY">Libya</option>
                                <option value="LI">Liechtenstein</option>
                                <option value="LT">Lithuania</option>
                                <option value="LU">Luxembourg</option>
                                <option value="MO">Macau SAR China</option>
                                <option value="MK">Macedonia</option>
                                <option value="MG">Madagascar</option>
                                <option value="MW">Malawi</option>
                                <option value="MY">Malaysia</option>
                                <option value="MV">Maldives</option>
                                <option value="ML">Mali</option>
                                <option value="MT">Malta</option>
                                <option value="MH">Marshall Islands</option>
                                <option value="MQ">Martinique</option>
                                <option value="MR">Mauritania</option>
                                <option value="MU">Mauritius</option>
                                <option value="YT">Mayotte</option>
                                <option value="MX">Mexico</option>
                                <option value="FM">Micronesia</option>
                                <option value="MD">Moldova</option>
                                <option value="MC">Monaco</option>
                                <option value="MN">Mongolia</option>
                                <option value="ME">Montenegro</option>
                                <option value="MS">Montserrat</option>
                                <option value="MA">Morocco</option>
                                <option value="MZ">Mozambique</option>
                                <option value="MM">Myanmar [Burma]</option>
                                <option value="NA">Namibia</option>
                                <option value="NR">Nauru</option>
                                <option value="NP">Nepal</option>
                                <option value="NL">Netherlands</option>
                                <option value="AN">Netherlands Antilles</option>
                                <option value="NC">New Caledonia</option>
                                <option value="NZ">New Zealand</option>
                                <option value="NI">Nicaragua</option>
                                <option value="NE">Niger</option>
                                <option value="NG">Nigeria</option>
                                <option value="NU">Niue</option>
                                <option value="NF">Norfolk Island</option>
                                <option value="KP">North Korea</option>
                                <option value="MP">Northern Mariana Islands</option>
                                <option value="NO">Norway</option>
                                <option value="OM">Oman</option>
                                <option value="PK">Pakistan</option>
                                <option value="PW">Palau</option>
                                <option value="PS">Palestinian Territories</option>
                                <option value="PA">Panama</option>
                                <option value="PG">Papua New Guinea</option>
                                <option value="PY">Paraguay</option>
                                <option value="PE">Peru</option>
                                <option value="PH">Philippines</option>
                                <option value="PN">Pitcairn Islands</option>
                                <option value="PL">Poland</option>
                                <option value="PT">Portugal</option>
                                <option value="PR">Puerto Rico</option>
                                <option value="QA">Qatar</option>
                                <option value="RO">Romania</option>
                                <option value="RU">Russia</option>
                                <option value="RW">Rwanda</option>
                                <option value="RE">Réunion</option>
                                <option value="BL">Saint Barthélemy</option>
                                <option value="SH">Saint Helena</option>
                                <option value="KN">Saint Kitts and Nevis</option>
                                <option value="LC">Saint Lucia</option>
                                <option value="MF">Saint Martin</option>
                                <option value="PM">Saint Pierre and Miquelon</option>
                                <option value="VC">Saint Vincent and the Grenadines</option>
                                <option value="WS">Samoa</option>
                                <option value="SM">San Marino</option>
                                <option value="SA">Saudi Arabia</option>
                                <option value="SN">Senegal</option>
                                <option value="RS">Serbia</option>
                                <option value="SC">Seychelles</option>
                                <option value="SL">Sierra Leone</option>
                                <option value="SG">Singapore</option>
                                <option value="SK">Slovakia</option>
                                <option value="SI">Slovenia</option>
                                <option value="SB">Solomon Islands</option>
                                <option value="SO">Somalia</option>
                                <option value="ZA">South Africa</option>
                                <option value="GS">South Georgia and the South Sandwich Islands</option>
                                <option value="KR">South Korea</option>
                                <option value="ES">Spain</option>
                                <option value="LK">Sri Lanka</option>
                                <option value="SD">Sudan</option>
                                <option value="SR">Suriname</option>
                                <option value="SJ">Svalbard and Jan Mayen</option>
                                <option value="SZ">Swaziland</option>
                                <option value="SE">Sweden</option>
                                <option value="CH">Switzerland</option>
                                <option value="SY">Syria</option>
                                <option value="ST">São Tomé and Príncipe</option>
                                <option value="TW">Taiwan</option>
                                <option value="TJ">Tajikistan</option>
                                <option value="TZ">Tanzania</option>
                                <option value="TH">Thailand</option>
                                <option value="TL">Timor-Leste</option>
                                <option value="TG">Togo</option>
                                <option value="TK">Tokelau</option>
                                <option value="TO">Tonga</option>
                                <option value="TT">Trinidad and Tobago</option>
                                <option value="TN">Tunisia</option>
                                <option value="TR">Turkey</option>
                                <option value="TM">Turkmenistan</option>
                                <option value="TC">Turks and Caicos Islands</option>
                                <option value="TV">Tuvalu</option>
                                <option value="UM">U.S. Minor Outlying Islands</option>
                                <option value="VI">U.S. Virgin Islands</option>
                                <option value="UG">Uganda</option>
                                <option value="UA">Ukraine</option>
                                <option value="AE">United Arab Emirates</option>
                                <option value="GB">United Kingdom</option>
                                <option value="US" selected="selected">United States</option>
                                <option value="UY">Uruguay</option>
                                <option value="UZ">Uzbekistan</option>
                                <option value="VU">Vanuatu</option>
                                <option value="VA">Vatican City</option>
                                <option value="VE">Venezuela</option>
                                <option value="VN">Vietnam</option>
                                <option value="WF">Wallis and Futuna</option>
                                <option value="EH">Western Sahara</option>
                                <option value="YE">Yemen</option>
                                <option value="ZM">Zambia</option>
                                <option value="ZW">Zimbabwe</option>
                                <option value="AX">Åland Islands</option>
                              </select>
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Telephone <span class="required">*</span></label>
                              <br />
                              <input type="text" name="billing[telephone]" title="Telephone" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Fax</label>
                              <br />
                              <input type="text" name="billing[fax]" title="Fax" class="input-text" />
                            </div>
                          </li>
                          <li id="register-customer-password">
                            <div class="input-box">
                              <label>Password <span class="required">*</span></label>
                              <br />
                              <input type="password" name="billing[customer_password]" title="Password" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Confirm Password <span class="required">*</span></label>
                              <br />
                              <input type="password" name="billing[confirm_password]" title="Confirm Password" class="input-text" />
                            </div>
                          </li>
                          <li>
                            <input type="hidden" name="billing[save_in_address_book]" value="1" />
                          </li>
                        </ul>
                      </fieldset>
                    </li>
                    <li class="control">
                      <input type="radio" class="radio" title="Ship to this address" checked="checked" value="1" name="billing[use_for_shipping]">
                      <label>Ship to this address</label>
                    </li>
                    <li class="control">
                      <input type="radio" class="radio" title="Ship to different address" value="0" name="billing[use_for_shipping]">
                      <label>Ship to different address</label>
                    </li>
                  </ul>
                  <p class="require"><em class="required">* </em>Required Fields</p>
                  <button type="button" class="button continue" ><span>Continue</span></button>
                </fieldset>
              </form>
            </div>
          </li>
          <li id="opc-shipping" class="section">
            <div class="step-title"> <span class="number">3</span>
              <h3 class="one_page_heading">Shipping Information</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-shipping" class="step a-item" style="display: none;">
              <form>
                <fieldset class="group-select">
                  <ul>
                    <li id="shipping-new-address-form">
                      <fieldset>
                        <input type="hidden" name="shipping[address_id]" value="9681" />
                        <ul>
                          <li>
                            <div class="customer-name">
                              <div class="input-box name-firstname">
                                <label> First Name <span class="required">*</span> </label>
                                <br />
                                <input type="text" name="shipping[firstname]" title="First Name" class="input-text" />
                              </div>
                              <div class="input-box name-lastname">
                                <label> Last Name <span class="required">*</span> </label>
                                <br />
                                <input type="text" name="shipping[lastname]" title="Last Name" class="input-text" />
                              </div>
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Company</label>
                              <br />
                              <input type="text" name="shipping[company]" title="Company" class="input-text" />
                            </div>
                          </li>
                          <li>
                            <label>Address <span class="required">*</span></label>
                            <br />
                            <input type="text" title="Street Address" name="shipping[street][]" class="input-text" />
                          </li>
                          <li>
                            <input type="text" title="Street Address 2" name="shipping[street][]" class="input-text" />
                          </li>
                          <li>
                            <div class="input-box">
                              <label>City <span class="required">*</span></label>
                              <br />
                              <input type="text" title="City" name="shipping[city]" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>State/Province <span class="required">*</span></label>
                              <br />
                              <select name="shipping[region_id]" title="State/Province" class="validate-select">
                                <option>Please select region, state or province</option>
                                <option value="1">Alabama</option>
                                <option value="2">Alaska</option>
                                <option value="3">American Samoa</option>
                                <option value="4">Arizona</option>
                                <option value="5">Arkansas</option>
                                <option value="6">Armed Forces Africa</option>
                                <option value="7">Armed Forces Americas</option>
                                <option value="8">Armed Forces Canada</option>
                                <option value="9">Armed Forces Europe</option>
                                <option value="10">Armed Forces Middle East</option>
                                <option value="11">Armed Forces Pacific</option>
                                <option value="12">California</option>
                                <option value="13">Colorado</option>
                                <option value="14">Connecticut</option>
                                <option value="15">Delaware</option>
                                <option value="16">District of Columbia</option>
                                <option value="17">Federated States Of Micronesia</option>
                                <option value="18">Florida</option>
                                <option value="19">Georgia</option>
                                <option value="20">Guam</option>
                                <option value="21">Hawaii</option>
                                <option value="22">Idaho</option>
                                <option value="23">Illinois</option>
                                <option value="24">Indiana</option>
                                <option value="25">Iowa</option>
                                <option value="26">Kansas</option>
                                <option value="27">Kentucky</option>
                                <option value="28">Louisiana</option>
                                <option value="29">Maine</option>
                                <option value="30">Marshall Islands</option>
                                <option value="31">Maryland</option>
                                <option value="32">Massachusetts</option>
                                <option value="33">Michigan</option>
                                <option value="34">Minnesota</option>
                                <option value="35">Mississippi</option>
                                <option value="36">Missouri</option>
                                <option value="37">Montana</option>
                                <option value="38">Nebraska</option>
                                <option value="39">Nevada</option>
                                <option value="40">New Hampshire</option>
                                <option value="41">New Jersey</option>
                                <option value="42">New Mexico</option>
                                <option value="43">New York</option>
                                <option value="44">North Carolina</option>
                                <option value="45">North Dakota</option>
                                <option value="46">Northern Mariana Islands</option>
                                <option value="47">Ohio</option>
                                <option value="48">Oklahoma</option>
                                <option value="49">Oregon</option>
                                <option value="50">Palau</option>
                                <option value="51">Pennsylvania</option>
                                <option value="52">Puerto Rico</option>
                                <option value="53">Rhode Island</option>
                                <option value="54">South Carolina</option>
                                <option value="55">South Dakota</option>
                                <option value="56">Tennessee</option>
                                <option value="57">Texas</option>
                                <option value="58">Utah</option>
                                <option value="59">Vermont</option>
                                <option value="60">Virgin Islands</option>
                                <option value="61">Virginia</option>
                                <option value="62">Washington</option>
                                <option value="63">West Virginia</option>
                                <option value="64">Wisconsin</option>
                                <option value="65">Wyoming</option>
                              </select>
                              <input type="text" name="shipping[region]" title="State/Province" class="input-text" style="display: none;" />
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Zip/Postal Code <span class="required">*</span></label>
                              <br />
                              <input type="text" title="Zip/Postal Code" name="shipping[postcode]" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Country <span class="required">*</span></label>
                              <br />
                              <select name="shipping[country_id]" class="validate-select" title="Country">
                                <option value="AF">Afghanistan</option>
                                <option value="AL">Albania</option>
                                <option value="DZ">Algeria</option>
                                <option value="AS">American Samoa</option>
                                <option value="AD">Andorra</option>
                                <option value="AO">Angola</option>
                                <option value="AI">Anguilla</option>
                                <option value="AQ">Antarctica</option>
                                <option value="AG">Antigua and Barbuda</option>
                                <option value="AR">Argentina</option>
                                <option value="AM">Armenia</option>
                                <option value="AW">Aruba</option>
                                <option value="AU">Australia</option>
                                <option value="AT">Austria</option>
                                <option value="AZ">Azerbaijan</option>
                                <option value="BS">Bahamas</option>
                                <option value="BH">Bahrain</option>
                                <option value="BD">Bangladesh</option>
                                <option value="BB">Barbados</option>
                                <option value="BY">Belarus</option>
                                <option value="BE">Belgium</option>
                                <option value="BZ">Belize</option>
                                <option value="BJ">Benin</option>
                                <option value="BM">Bermuda</option>
                                <option value="BT">Bhutan</option>
                                <option value="BO">Bolivia</option>
                                <option value="BA">Bosnia and Herzegovina</option>
                                <option value="BW">Botswana</option>
                                <option value="BV">Bouvet Island</option>
                                <option value="BR">Brazil</option>
                                <option value="IO">British Indian Ocean Territory</option>
                                <option value="VG">British Virgin Islands</option>
                                <option value="BN">Brunei</option>
                                <option value="BG">Bulgaria</option>
                                <option value="BF">Burkina Faso</option>
                                <option value="BI">Burundi</option>
                                <option value="KH">Cambodia</option>
                                <option value="CM">Cameroon</option>
                                <option value="CA">Canada</option>
                                <option value="CV">Cape Verde</option>
                                <option value="KY">Cayman Islands</option>
                                <option value="CF">Central African Republic</option>
                                <option value="TD">Chad</option>
                                <option value="CL">Chile</option>
                                <option value="CN">China</option>
                                <option value="CX">Christmas Island</option>
                                <option value="CC">Cocos [Keeling] Islands</option>
                                <option value="CO">Colombia</option>
                                <option value="KM">Comoros</option>
                                <option value="CG">Congo - Brazzaville</option>
                                <option value="CD">Congo - Kinshasa</option>
                                <option value="CK">Cook Islands</option>
                                <option value="CR">Costa Rica</option>
                                <option value="HR">Croatia</option>
                                <option value="CU">Cuba</option>
                                <option value="CY">Cyprus</option>
                                <option value="CZ">Czech Republic</option>
                                <option value="CI">Côte d’Ivoire</option>
                                <option value="DK">Denmark</option>
                                <option value="DJ">Djibouti</option>
                                <option value="DM">Dominica</option>
                                <option value="DO">Dominican Republic</option>
                                <option value="EC">Ecuador</option>
                                <option value="EG">Egypt</option>
                                <option value="SV">El Salvador</option>
                                <option value="GQ">Equatorial Guinea</option>
                                <option value="ER">Eritrea</option>
                                <option value="EE">Estonia</option>
                                <option value="ET">Ethiopia</option>
                                <option value="FK">Falkland Islands</option>
                                <option value="FO">Faroe Islands</option>
                                <option value="FJ">Fiji</option>
                                <option value="FI">Finland</option>
                                <option value="FR">France</option>
                                <option value="GF">French Guiana</option>
                                <option value="PF">French Polynesia</option>
                                <option value="TF">French Southern Territories</option>
                                <option value="GA">Gabon</option>
                                <option value="GM">Gambia</option>
                                <option value="GE">Georgia</option>
                                <option value="DE">Germany</option>
                                <option value="GH">Ghana</option>
                                <option value="GI">Gibraltar</option>
                                <option value="GR">Greece</option>
                                <option value="GL">Greenland</option>
                                <option value="GD">Grenada</option>
                                <option value="GP">Guadeloupe</option>
                                <option value="GU">Guam</option>
                                <option value="GT">Guatemala</option>
                                <option value="GG">Guernsey</option>
                                <option value="GN">Guinea</option>
                                <option value="GW">Guinea-Bissau</option>
                                <option value="GY">Guyana</option>
                                <option value="HT">Haiti</option>
                                <option value="HM">Heard Island and McDonald Islands</option>
                                <option value="HN">Honduras</option>
                                <option value="HK">Hong Kong SAR China</option>
                                <option value="HU">Hungary</option>
                                <option value="IS">Iceland</option>
                                <option value="IN">India</option>
                                <option value="ID">Indonesia</option>
                                <option value="IR">Iran</option>
                                <option value="IQ">Iraq</option>
                                <option value="IE">Ireland</option>
                                <option value="IM">Isle of Man</option>
                                <option value="IL">Israel</option>
                                <option value="IT">Italy</option>
                                <option value="JM">Jamaica</option>
                                <option value="JP">Japan</option>
                                <option value="JE">Jersey</option>
                                <option value="JO">Jordan</option>
                                <option value="KZ">Kazakhstan</option>
                                <option value="KE">Kenya</option>
                                <option value="KI">Kiribati</option>
                                <option value="KW">Kuwait</option>
                                <option value="KG">Kyrgyzstan</option>
                                <option value="LA">Laos</option>
                                <option value="LV">Latvia</option>
                                <option value="LB">Lebanon</option>
                                <option value="LS">Lesotho</option>
                                <option value="LR">Liberia</option>
                                <option value="LY">Libya</option>
                                <option value="LI">Liechtenstein</option>
                                <option value="LT">Lithuania</option>
                                <option value="LU">Luxembourg</option>
                                <option value="MO">Macau SAR China</option>
                                <option value="MK">Macedonia</option>
                                <option value="MG">Madagascar</option>
                                <option value="MW">Malawi</option>
                                <option value="MY">Malaysia</option>
                                <option value="MV">Maldives</option>
                                <option value="ML">Mali</option>
                                <option value="MT">Malta</option>
                                <option value="MH">Marshall Islands</option>
                                <option value="MQ">Martinique</option>
                                <option value="MR">Mauritania</option>
                                <option value="MU">Mauritius</option>
                                <option value="YT">Mayotte</option>
                                <option value="MX">Mexico</option>
                                <option value="FM">Micronesia</option>
                                <option value="MD">Moldova</option>
                                <option value="MC">Monaco</option>
                                <option value="MN">Mongolia</option>
                                <option value="ME">Montenegro</option>
                                <option value="MS">Montserrat</option>
                                <option value="MA">Morocco</option>
                                <option value="MZ">Mozambique</option>
                                <option value="MM">Myanmar [Burma]</option>
                                <option value="NA">Namibia</option>
                                <option value="NR">Nauru</option>
                                <option value="NP">Nepal</option>
                                <option value="NL">Netherlands</option>
                                <option value="AN">Netherlands Antilles</option>
                                <option value="NC">New Caledonia</option>
                                <option value="NZ">New Zealand</option>
                                <option value="NI">Nicaragua</option>
                                <option value="NE">Niger</option>
                                <option value="NG">Nigeria</option>
                                <option value="NU">Niue</option>
                                <option value="NF">Norfolk Island</option>
                                <option value="KP">North Korea</option>
                                <option value="MP">Northern Mariana Islands</option>
                                <option value="NO">Norway</option>
                                <option value="OM">Oman</option>
                                <option value="PK">Pakistan</option>
                                <option value="PW">Palau</option>
                                <option value="PS">Palestinian Territories</option>
                                <option value="PA">Panama</option>
                                <option value="PG">Papua New Guinea</option>
                                <option value="PY">Paraguay</option>
                                <option value="PE">Peru</option>
                                <option value="PH">Philippines</option>
                                <option value="PN">Pitcairn Islands</option>
                                <option value="PL">Poland</option>
                                <option value="PT">Portugal</option>
                                <option value="PR">Puerto Rico</option>
                                <option value="QA">Qatar</option>
                                <option value="RO">Romania</option>
                                <option value="RU">Russia</option>
                                <option value="RW">Rwanda</option>
                                <option value="RE">Réunion</option>
                                <option value="BL">Saint Barthélemy</option>
                                <option value="SH">Saint Helena</option>
                                <option value="KN">Saint Kitts and Nevis</option>
                                <option value="LC">Saint Lucia</option>
                                <option value="MF">Saint Martin</option>
                                <option value="PM">Saint Pierre and Miquelon</option>
                                <option value="VC">Saint Vincent and the Grenadines</option>
                                <option value="WS">Samoa</option>
                                <option value="SM">San Marino</option>
                                <option value="SA">Saudi Arabia</option>
                                <option value="SN">Senegal</option>
                                <option value="RS">Serbia</option>
                                <option value="SC">Seychelles</option>
                                <option value="SL">Sierra Leone</option>
                                <option value="SG">Singapore</option>
                                <option value="SK">Slovakia</option>
                                <option value="SI">Slovenia</option>
                                <option value="SB">Solomon Islands</option>
                                <option value="SO">Somalia</option>
                                <option value="ZA">South Africa</option>
                                <option value="GS">South Georgia and the South Sandwich Islands</option>
                                <option value="KR">South Korea</option>
                                <option value="ES">Spain</option>
                                <option value="LK">Sri Lanka</option>
                                <option value="SD">Sudan</option>
                                <option value="SR">Suriname</option>
                                <option value="SJ">Svalbard and Jan Mayen</option>
                                <option value="SZ">Swaziland</option>
                                <option value="SE">Sweden</option>
                                <option value="CH">Switzerland</option>
                                <option value="SY">Syria</option>
                                <option value="ST">São Tomé and Príncipe</option>
                                <option value="TW">Taiwan</option>
                                <option value="TJ">Tajikistan</option>
                                <option value="TZ">Tanzania</option>
                                <option value="TH">Thailand</option>
                                <option value="TL">Timor-Leste</option>
                                <option value="TG">Togo</option>
                                <option value="TK">Tokelau</option>
                                <option value="TO">Tonga</option>
                                <option value="TT">Trinidad and Tobago</option>
                                <option value="TN">Tunisia</option>
                                <option value="TR">Turkey</option>
                                <option value="TM">Turkmenistan</option>
                                <option value="TC">Turks and Caicos Islands</option>
                                <option value="TV">Tuvalu</option>
                                <option value="UM">U.S. Minor Outlying Islands</option>
                                <option value="VI">U.S. Virgin Islands</option>
                                <option value="UG">Uganda</option>
                                <option value="UA">Ukraine</option>
                                <option value="AE">United Arab Emirates</option>
                                <option value="GB">United Kingdom</option>
                                <option value="US" selected="selected">United States</option>
                                <option value="UY">Uruguay</option>
                                <option value="UZ">Uzbekistan</option>
                                <option value="VU">Vanuatu</option>
                                <option value="VA">Vatican City</option>
                                <option value="VE">Venezuela</option>
                                <option value="VN">Vietnam</option>
                                <option value="WF">Wallis and Futuna</option>
                                <option value="EH">Western Sahara</option>
                                <option value="YE">Yemen</option>
                                <option value="ZM">Zambia</option>
                                <option value="ZW">Zimbabwe</option>
                                <option value="AX">Åland Islands</option>
                              </select>
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Telephone <span class="required">*</span></label>
                              <br />
                              <input type="text" name="shipping[telephone]" title="Telephone" class="input-text" />
                            </div>
                            <div class="input-box">
                              <label>Fax</label>
                              <br />
                              <input type="text" name="shipping[fax]" title="Fax" class="input-text" />
                            </div>
                          </li>
                          <li class="no-display">
                            <input type="hidden" name="shipping[save_in_address_book]" value="1" />
                          </li>
                          <li>
                            <input type="checkbox" name="shipping[same_as_billing]" value="1" class="checkbox" />
                            <label>Use Billing Address</label>
                          </li>
                        </ul>
                      </fieldset>
                    </li>
                  </ul>
                  <p class="require"><em class="required">* </em>Required Fields</p>
                  <div class="buttons-set1" id="shipping-buttons-container">
                    <button type="button" class="button continue" ><span>Continue</span></button>
                    <a href="#" class="back-link">« Back</a> </div>
                </fieldset>
              </form>
            </div>
          </li>
          <li id="opc-shipping_method" class="section">
            <div class="step-title"> <span class="number">4</span>
              <h3 class="one_page_heading">Shipping Method</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-shipping_method" class="step a-item" style="display: none;">
              <form>
                <fieldset>
                  <div id="checkout-shipping-method-load">
                    <p>Sorry, no quotes are available for this order at this time.</p>
                  </div>
                  <div id="onepage-checkout-shipping-method-additional-load">
                    <div class="add-gift-message">
                      <h4>Do you have any gift items in your order?</h4>
                      <p>
                        <input type="checkbox" name="allow_gift_messages" value="1" class="checkbox" />
                        <label>Check this checkbox if you want to add gift messages.</label>
                      </p>
                    </div>
                    <div style="display: none;" class="gift-message-form" id="allow-gift-message-container">
                      <div class="inner-box"> </div>
                    </div>
                  </div>
                  <div class="buttons-set1" id="shipping-method-buttons-container">
                    <button type="button" class="button continue"><span>Continue</span></button>
                    <a href="#" class="back-link">« Back</a> </div>
                </fieldset>
              </form>
            </div>
          </li>
          <li id="opc-payment" class="section">
            <div class="step-title"> <span class="number">5</span>
              <h3 class="one_page_heading">Payment Information</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-payment" class="step a-item" style="display: none;">
              <form id="co-payment-form">
                <dl id="checkout-payment-method-load">
                  <dt>
                    <input type="radio" value="checkmo" name="payment[method]" title="Check / Money order" class="radio" />
                    <label>Check / Money order</label>
                  </dt>
                  <dd>
                    <fieldset class="form-list">
                    </fieldset>
                  </dd>
                  <dt>
                    <input type="radio" value="ccsave" name="payment[method]" title="Credit Card (saved)" class="radio" />
                    <label>Credit Card (saved)</label>
                  </dt>
                  <dd>
                    <fieldset class="form-list">
                      <ul id="payment_form_ccsave" style="display: none;">
                        <li>
                          <div class="input-box">
                            <label>Name on Card <span class="required">*</span></label>
                            <br />
                            <input type="text" title="Name on Card" class="input-text" name="payment[cc_owner]" />
                          </div>
                        </li>
                        <li>
                          <div class="input-box">
                            <label for="ccsave_cc_type">Credit Card Type <span class="required">*</span></label>
                            <br />
                            <select id="ccsave_cc_type" name="payment[cc_type]" class="required-entry validate-cc-type-select">
                              <option>--Please Select--</option>
                              <option value="AE">American Express</option>
                              <option value="VI">Visa</option>
                              <option value="MC">MasterCard</option>
                              <option value="DI">Discover</option>
                            </select>
                          </div>
                        </li>
                        <li>
                          <div class="input-box">
                            <label>Credit Card Number <span class="required">*</span></label>
                            <br />
                            <input type="text" name="payment[cc_number]" title="Credit Card Number" class="input-text validate-cc-number validate-cc-type" />
                          </div>
                        </li>
                        <li>
                          <div class="input-box">
                            <label>Expiration Date <span class="required">*</span></label>
                            <br />
                            <div class="v-fix">
                              <select style="width: 140px;" name="payment[cc_exp_month]" class="required-entry">
                                <option selected="selected">Month</option>
                                <option value="1">01 - January</option>
                                <option value="2">02 - February</option>
                                <option value="3">03 - March</option>
                                <option value="4">04 - April</option>
                                <option value="5">05 - May</option>
                                <option value="6">06 - June</option>
                                <option value="7">07 - July</option>
                                <option value="8">08 - August</option>
                                <option value="9">09 - September</option>
                                <option value="10">10 - October</option>
                                <option value="11">11 - November</option>
                                <option value="12">12 - December</option>
                              </select>
                            </div>
                            <div class="v-fix">
                              <select style="width: 103px;" name="payment[cc_exp_year]" class="required-entry">
                                <option selected="selected">Year</option>
                                <option value="2011">2011</option>
                                <option value="2012">2012</option>
                                <option value="2013">2013</option>
                                <option value="2014">2014</option>
                                <option value="2015">2015</option>
                                <option value="2016">2016</option>
                                <option value="2017">2017</option>
                                <option value="2018">2018</option>
                                <option value="2019">2019</option>
                                <option value="2020">2020</option>
                                <option value="2021">2021</option>
                              </select>
                            </div>
                          </div>
                        </li>
                        <li>
                          <div class="input-box">
                            <label>Card Verification Number <span class="required">*</span></label>
                            <br />
                            <div class="v-fix">
                              <input type="text" title="Card Verification Number" class="input-text" name="payment[cc_cid]" style="width: 3em;" />
                            </div>
                            <a href="#" class="cvv-what-is-this">What is this?</a> </div>
                        </li>
                      </ul>
                    </fieldset>
                  </dd>
                </dl>
              </form>
              <p class="require"><em class="required">* </em>Required Fields</p>
              <div class="buttons-set1" id="payment-buttons-container">
                <button type="button" class="button continue" ><span>Continue</span></button>
                <a href="#" class="back-link">« Back</a> </div>
              <div style="clear: both;"></div>
            </div>
          </li>
          <li id="opc-review" class="section">
            <div class="step-title"> <span class="number">6</span>
              <h3 class="one_page_heading">Order Review</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-review" class="step a-item" style="display: none;">
              <div class="order-review" id="checkout-review-load"> </div>
              <div class="buttons-set13" id="review-buttons-container">
                <p class="f-left">Forgot an Item? <a href="#">Edit Your Cart</a></p>
                <button type="submit" class="button"><span>Place Order</span></button>
              </div>
            </div>
          </li>
        </ol>
      </div>
      <aside class="col-right sidebar col-sm-3">
        <div class="block block-progress">
          <div class="block-title ">Your Checkout</div>
          <div class="block-content">
            <dl>
              <dt class="complete"> Billing Address <span class="separator">|</span> <a href="#">Change</a> </dt>
              <dd class="complete">
                <address>
                swapna taru<br>
                Better Technology Labs.<br>
                23 North Main Stree<br>
                Windsor<br>
                Holtsville,  New York, 00501<br>
                United States<br>
                T: 5465465 <br>
                F: 466523
                </address>
              </dd>
              <dt class="complete"> Shipping Address <span class="separator">|</span> <a href="#">Change</a> </dt>
              <dd class="complete">
                <address>
                swapna taru<br>
                Better Technology Labs.<br>
                23 North Main Stree<br>
                Windsor<br>
                Holtsville,  New York, 00501<br>
                United States<br>
                T: 5465465 <br>
                F: 466523
                </address>
              </dd>
              <dt class="complete"> Shipping Method <span class="separator">|</span> <a href="#">Change</a> </dt>
              <dd class="complete"> Flat Rate - Fixed <br>
                <span class="price">$15.00</span> </dd>
              <dt> Payment Method </dt>
              <dd>&nbsp; </dd>
            </dl>
          </div>
        </div>
      </aside>
    </div>
  </div>
</section>
<!-- Main Container end --> 
</asp:Content>

