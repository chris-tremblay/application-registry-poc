import React, { Component } from 'react';
import PropTypes, { string } from "prop-types";

class MemberDetailView extends Component {
  static displayName = MemberDetailView.name;
  static displayName2 = "displayName2";

  static propTypes(){
    return {
      maxValue: PropTypes.number,
      value: PropTypes.number,
      onRatingUpdatedEvt: PropTypes.func
    };
  }

  constructor(props) {
    super(props);
    this.state = { memberData: null, loading: true };
  }

  componentDidMount() {
    this.populateDetails();
  }

  static renderMemberData(memberData) {
    return (
      <table className='table' aria-labelledby="tabelLabel">
        <tbody>
        <tr>
            <th>First Name:</th>
            <td>{memberData.firstName}</td>
            <th>Last Name:</th>
            <td>{memberData.lastName}</td>
          </tr>
          <tr>
            <th>Birth Date:</th>
            <td>{memberData.birthData}</td>
            <th>Plan #:</th>
            <td>{memberData.planNumber}</td>
          </tr>
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : MemberDetailView.renderMemberData(this.state.memberData);

    return (
        <div>
           {contents}
        </div>
    );
  }

  async populateDetails() {
    const response = await fetch('http://localhost:45275/member');
    const data = await response.json();
    this.setState({ memberData: data, loading: false });
  }
}

export default MemberDetailView;