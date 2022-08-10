import React, { Component } from 'react';

export default class MemberDetailView extends Component {
  static displayName = MemberDetailView.name;

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
    const response = await fetch('member');
    const data = await response.json();
    this.setState({ memberData: data, loading: false });
  }
}