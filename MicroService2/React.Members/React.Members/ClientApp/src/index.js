import React from 'react';
import ReactDOM from "react-dom";
import Counter from './components/Counter';
import MemberDetailView from './components/MemberDetailView';
import reactToWebComponent from "react-to-webcomponent";

//customElements.define("mnc-members-react-counter", reactToWebComponent(Counter, React, ReactDOM));
customElements.define("mnc-members-member-detail-view", reactToWebComponent(MemberDetailView, React, ReactDOM));