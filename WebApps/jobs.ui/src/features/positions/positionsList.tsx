import { JSX } from "react"
import { useGetPositionsQuery } from "../../services/positionsApiSlice"

export const Positions = (): JSX.Element | null => {
    const { data, isError, isLoading, isSuccess } = useGetPositionsQuery()

    if (isError) {
        return (
            <div>
                <h1>There was an error fetching positions!</h1>
            </div>
        )
    }

    if (isLoading) {
        return (
            <div>
                <h1>Loading positions...</h1>
            </div>
        )
    }

    if (isSuccess) {
        return (
            <div>
                <h2>Positions List</h2>
                <ul>
                    {data.positions.map(position => (
                        <li key={position.id}>
                            <h3>{position.title}</h3>
                            <p>{position.description}</p>
                            <p><strong>Location:</strong> {position.location}</p>
                            <p><strong>Status:</strong> {position.status}</p>
                            <p><strong>Recruiter:</strong> {position.Recruiter}</p>
                            <p><strong>Department:</strong> {position.Department}</p>
                            <p><strong>Budget:</strong> ${position.Budget}</p>
                            <p><strong>Closing Date:</strong> {new Date(position.ClosingDate).toLocaleDateString()}</p>
                        </li>
                    ))}
                </ul>
            </div>
        )
    }

    return null
}